using Contracts;
using Service.Contracts;

namespace Service;

public sealed class TagService : ITagService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;

	public TagService(IRepositoryManager repository, ILoggerManager logger)
	{
		_repository = repository;
		_logger = logger;
	}
}
