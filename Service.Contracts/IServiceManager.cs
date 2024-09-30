namespace Service.Contracts;

public interface IServiceManager
{
	IPostService PostService { get; }
	ITagService TagService { get; }
	ILikeService LikeService { get; }

	ICommentService CommentService { get; }

	//IUserService
}
