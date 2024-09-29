using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class LikeService : ILikeService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public LikeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}
}
