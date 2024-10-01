using Shared.DTO.LikeDtos;

namespace Service.Contracts;

public interface ILikeService
{
	LikeDto ToggleLike(Guid postId, string userId, bool trackChanges);
}
