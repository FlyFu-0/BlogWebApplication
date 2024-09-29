using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class PostService : IPostService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public PostService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public IEnumerable<PostDto> GetAllPosts(bool trackChanges)
	{
		try
		{
			var posts = _repository.Post.GetAllPosts(trackChanges);
			var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

			return postsDto;
		}
		catch (Exception ex)
		{
			_logger.LogError($"Something went wrong in the {nameof(GetAllPosts)} service method {ex}");
			throw;
		}
	}
}