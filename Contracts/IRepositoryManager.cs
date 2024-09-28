using Repository.ModelsRepository;

namespace Contracts;

public interface IRepositoryManager
{
	IPostRepository Post { get; }
	ITagRepository Tag { get; }
	ILikeRepository Like { get; }

	void Save();
}
