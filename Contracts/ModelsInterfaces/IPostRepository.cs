using Entities;

namespace Repository.ModelsRepository;

public interface IPostRepository
{
	Task<IEnumerable<Post>> GetAllPosts(bool trackChanges);
	Task<Post> GetPost(Guid postId, bool trackChanges);

	void CreatePost(Post post);

	void DeletePost(Post post);
}
