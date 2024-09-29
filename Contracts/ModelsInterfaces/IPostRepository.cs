using Entities;

namespace Repository.ModelsRepository;

public interface IPostRepository
{
	IEnumerable<Post> GetAllPosts(bool trackChanges);
}
