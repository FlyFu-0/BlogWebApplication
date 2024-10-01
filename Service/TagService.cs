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

	public TagDto CreateTag(TagCreationDto tag)
	{
		var tagEntity = _mapper.Map<Tag>(tag);

		_repository.Tag.CreateTag(tagEntity);
		_repository.Save();

		var tagToRetun = _mapper.Map<TagDto>(tagEntity);

		return tagToRetun;
	}

	public void DeleteTag(Guid tagId, bool trackChanges)
	{
		var tag = _repository.Tag.GetTag(tagId, trackChanges);
		if (tag is null)
			throw new TagNotFoundException(tagId);

		_repository.Tag.DeleteTag(tag);
		_repository.Save();
	}

	public IEnumerable<TagDto> GetAllTags(bool trackChanges)
	{
		var tags = _repository.Tag.GetAllTags(trackChanges);
		var tagsDto = _mapper.Map<IEnumerable<TagDto>>(tags);

		return tagsDto;
	}

	public TagDto GetTag(Guid tagId, bool trackChanges)
	{
		var tag = _repository.Tag.GetTag(tagId, trackChanges);
		var tagDto = _mapper.Map<TagDto>(tag);

		return tagDto;
	}

	public void UpdateTag(Guid tagId, TagUpdateDto tagForUpdate, bool trackChanges)
	{
		var tag = _repository.Tag.GetTag(tagId, trackChanges);
		if (tag is null)
			throw new TagNotFoundException(tagId);

		_mapper.Map(tagForUpdate, tag);
		_repository.Save();
	}
}
