using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.ModelsRepository;
using Shared.RequestFeatures;

namespace Repository;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
	public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
		=> await FindAll(trackChanges)
			.Include(p => p.Tags)
			.OrderBy(c => c.LikesCount)
			.Skip((postParameters.PageNumber - 1) * postParameters.PageSize)
			.Take(postParameters.PageSize)
			.ToListAsync();

	public async Task<Post> GetPostAsync(Guid postId, bool trackChanges)
		=> await FindByCondition(p => p.Id.Equals(postId), trackChanges)
			.Include(p => p.Tags)
			.SingleOrDefaultAsync();

	public void CreatePost(Post post)
		=> Create(post);

	public void DeletePost(Post post)
		=> Delete(post);
}
