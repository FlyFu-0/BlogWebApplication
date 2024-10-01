using Entities;
using Repository.ModelsRepository;

namespace Repository;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
	public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public IEnumerable<Post> GetAllPosts(bool trackChanges)
		=> FindAll(trackChanges)
			.OrderBy(c => c.LikesCount)
			.ToList();

	public Post GetPost(Guid postId, bool trackChanges)
		=> FindByCondition(p => p.Id.Equals(postId), trackChanges)
			.SingleOrDefault();

	public void CreatePost(Post post)
		=> Create(post);

	public void DeletePost(Post post)
		=> Delete(post);
}
