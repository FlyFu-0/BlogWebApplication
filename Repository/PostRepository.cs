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

	public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
	{
		var posts = await FindByCondition(p => !postParameters.TagId.HasValue || p.Tags.Any(t => postParameters.TagId.Equals(t.Id)), trackChanges)
				.Include(p => p.Tags)
				.OrderBy(c => c.LikesCount)
				.Skip((postParameters.PageNumber - 1) * postParameters.PageSize)
				.Take(postParameters.PageSize)
				.ToListAsync();

		var count = await FindAll(trackChanges).CountAsync();

		return new PagedList<Post>(posts, count, postParameters.PageNumber, postParameters.PageSize);
	}

	public async Task<Post> GetPostAsync(Guid postId, bool trackChanges)
		=> await FindByCondition(p => p.Id.Equals(postId), trackChanges)
			.Include(p => p.Tags)
			.SingleOrDefaultAsync();

	public void CreatePost(Post post)
		=> Create(post);

	public void DeletePost(Post post)
		=> Delete(post);
}
