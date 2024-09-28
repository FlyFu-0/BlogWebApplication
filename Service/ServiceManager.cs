using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IPostService> _postService;
	private readonly Lazy<ITagService> _tagService;
	private readonly Lazy<ILikeService> _likeService;

	public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
	{
		_postService = new Lazy<IPostService>(() => new PostService(repository, logger));
		_tagService = new Lazy<ITagService>(() => new TagService(repository, logger));
		_likeService = new Lazy<ILikeService>(() => new LikeService(repository, logger));
	}

	public IPostService PostService => _postService.Value;

	public ITagService TagService => _tagService.Value;

	public ILikeService LikeService => _likeService.Value;
}
