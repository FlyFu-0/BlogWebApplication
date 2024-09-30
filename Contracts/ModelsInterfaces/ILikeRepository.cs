using Entities;

namespace Repository.ModelsRepository;

public interface ILikeRepository
{
	void CreateLike(Guid postId, string userId);

}
