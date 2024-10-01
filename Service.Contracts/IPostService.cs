using Shared.DTO.PostDtos;

namespace Service.Contracts;

public interface IPostService
{
	IEnumerable<PostDto> GetAllPosts(bool trackChanges);

	PostDto GetPost(Guid postId, bool trackChanges);

	PostDto CreatePost(PostCreationDto post);

	void DeletePost(string userId, Guid postId, bool trackChanges);

	void UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges);
}
