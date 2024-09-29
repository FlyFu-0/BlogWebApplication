using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IPostService> _postService;
	private readonly Lazy<ITagService> _tagService;
	private readonly Lazy<ILikeService> _likeService;

	public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_postService = new Lazy<IPostService>(() => new PostService(repository, logger, mapper));
		_tagService = new Lazy<ITagService>(() => new TagService(repository, logger, mapper));
		_likeService = new Lazy<ILikeService>(() => new LikeService(repository, logger, mapper));
	}

	public IPostService PostService => _postService.Value;

	public ITagService TagService => _tagService.Value;

	public ILikeService LikeService => _likeService.Value;
}
