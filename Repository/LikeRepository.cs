using Entities;
using Repository.ModelsRepository;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
	public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public void CreateLike(Guid postId, string userId)
	{
		var like = new Like();
		like.UserId = userId;
		like.PostId = postId;
		Create(like);
	}
}
