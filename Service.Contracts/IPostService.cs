using Entities;
using Shared.DTO.PostDtos;

namespace Service.Contracts;

public interface IPostService
{
	Task<IEnumerable<PostDto>> GetAllPosts(bool trackChanges);

	Task<PostDto> GetPost(Guid postId, bool trackChanges);

	Task<PostDto> CreatePost(string userId, PostCreationDto post, bool trackChanges);

	Task DeletePost(string userId, Guid postId, bool trackChanges);
	Task UpdatePost(Guid postId, PostUpdateDto postForUpdate, bool trackChanges);

	Task<(PostUpdateDto postToPatch, Post postEntity)> GetPostForPatch(Guid postId, bool trackChanges);

	Task SaveToPatch(PostUpdateDto postToPatch, Post postEntity, bool trackChanges);
}
