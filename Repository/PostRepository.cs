using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.ModelsRepository;

namespace Repository;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
	public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Post>> GetAllPosts(bool trackChanges)
		=> await FindAll(trackChanges)
			.OrderBy(c => c.LikesCount)
			.Include(p => p.Tags)
			.ToListAsync();

	public async Task<Post> GetPost(Guid postId, bool trackChanges)
		=> await FindByCondition(p => p.Id.Equals(postId), trackChanges)
			.Include(p => p.Tags)
			.SingleOrDefaultAsync();

	public void CreatePost(Post post)
		=> Create(post);

	public void DeletePost(Post post)
		=> Delete(post);
}
