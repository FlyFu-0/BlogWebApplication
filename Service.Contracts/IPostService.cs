using Entities;
using Shared.DTO.PostDtos;

namespace Service.Contracts;

public interface IPostService
{
	IEnumerable<PostDto> GetAllPosts(bool trackChanges);

	PostDto GetPost(Guid postId, bool trackChanges);

	PostDto CreatePost(string userId, PostCreationDto post, bool trackChanges);

	void DeletePost(string userId, Guid postId, bool trackChanges);

	void UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges);

	(PostUpdateDto postToPatch, Post postEntity) GetPostForPatch(Guid postId, bool trackChanges);

	void SaveToPatch(PostUpdateDto postToPatch, Post postEntity, bool trackChanges);
}
