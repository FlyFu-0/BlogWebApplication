using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPostService
{
	IEnumerable<PostDto> GetAllPosts(bool trackChanges);
}
