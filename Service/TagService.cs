using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

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

	public IEnumerable<TagDto> GetAllTags(bool trackChanges)
	{
		try
		{
			var tags = _repository.Tag.GetAllTags(trackChanges);
			var tagsDto = _mapper.Map<IEnumerable<TagDto>>(tags);

			return tagsDto;
		}
		catch (Exception ex)
		{
			_logger.LogError($"Something went wrong {$"Something went wrong in the {nameof(GetAllTags)} service method {ex}"}");
			throw;
		}
	}
}
