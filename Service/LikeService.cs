using Contracts;
using Service.Contracts;

namespace Service;

public sealed class LikeService : ILikeService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;

	public LikeService(IRepositoryManager repository, ILoggerManager logger)
	{
		_repository = repository;
		_logger = logger;
	}
}
