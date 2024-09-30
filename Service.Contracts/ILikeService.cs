using Shared.DTO.LikeDtos;

namespace Service.Contracts;

public interface ILikeService
{
	LikeDto CreateLike(Guid postId, string userId, bool trackChanges);
}
