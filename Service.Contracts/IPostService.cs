using Shared.DTO.PostDtos;

namespace Service.Contracts;

public interface IPostService
{
	IEnumerable<PostDto> GetAllPosts(bool trackChanges);

	PostDto GetPost(Guid postId, bool trackChanges);
}
