using Entities;

namespace Repository.ModelsRepository;

public interface ILikeRepository
{
	void CreateLike(Guid postId, string userId);

	void DeleteLike(Like like);

	Like GetLike(Guid postId, string userId, bool trackChanges);
}
