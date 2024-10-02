using Entities;
using Shared.RequestFeatures;

namespace Repository.ModelsRepository;

public interface IPostRepository
{
	Task<IEnumerable<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges);
	Task<Post> GetPostAsync(Guid postId, bool trackChanges);

	void CreatePost(Post post);

	void DeletePost(Post post);
}
