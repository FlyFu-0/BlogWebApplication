namespace Service.Contracts;

public class IServiceManager
{
	IPostService PostService { get; }
	ITagService TagService { get; }
	ILikeService LikeService { get; }
}
