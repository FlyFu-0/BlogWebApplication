using Contracts;
using Entities;
using Service.Contracts;

namespace Service;

public sealed class PostService : IPostService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;

	public PostService(IRepositoryManager repository, ILoggerManager logger)
	{
		_repository = repository;
		_logger = logger;
	}

	public IEnumerable<Post> GetAllPosts(bool trackChanges)
	{
		try
		{
			var posts = _repository.Post.GetAllPosts(trackChanges);
			return posts;
		}
		catch (Exception ex)
		{
			_logger.LogError($"Something went wrong in the {nameof(GetAllPosts)} service method {ex}");
			throw;
		}
	}
}