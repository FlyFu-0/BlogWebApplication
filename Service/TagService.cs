using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTO.TagDtos;

namespace Service;

public sealed class TagService : ITagService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public TagService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<TagDto> CreateTag(TagCreationDto tag)
	{
		var tagEntity = _mapper.Map<Tag>(tag);

		_repository.Tag.CreateTag(tagEntity);
		await _repository.SaveAsync();

		var tagToRetun = _mapper.Map<TagDto>(tagEntity);

		return tagToRetun;
	}

	public async Task DeleteTag(Guid tagId, bool trackChanges)
	{
		var tag = await GetTagAndCheckIfEXist(tagId, trackChanges);

		_repository.Tag.DeleteTag(tag);
		await _repository.SaveAsync();
	}

	private async Task<Tag?> GetTagAndCheckIfEXist(Guid tagId, bool trackChanges)
	{
		var tag = await _repository.Tag.GetTagAsync(tagId, trackChanges);
		if (tag is null)
			throw new TagNotFoundException(tagId);
		return tag;
	}

	public async Task<IEnumerable<TagDto>> GetAllTags(bool trackChanges)
	{
		var tags = await _repository.Tag.GetAllTagsAsync(trackChanges);
		var tagsDto = _mapper.Map<IEnumerable<TagDto>>(tags);

		return tagsDto;
	}

	public async Task<TagDto> GetTag(Guid tagId, bool trackChanges)
	{
		var tag = await GetTagAndCheckIfEXist(tagId, trackChanges);

		var tagDto = _mapper.Map<TagDto>(tag);

		return tagDto;
	}

	public async Task UpdateTag(Guid tagId, TagUpdateDto tagForUpdate, bool trackChanges)
	{
		var tag = await GetTagAndCheckIfEXist(tagId, trackChanges);

		_mapper.Map(tagForUpdate, tag);
		await _repository.SaveAsync();
	}
}
