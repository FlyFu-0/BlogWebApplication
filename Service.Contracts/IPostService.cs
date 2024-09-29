using Entities;

namespace Service.Contracts;

public interface IPostService
{
	IEnumerable<Post> GetAllPosts(bool trackChanges);
}
