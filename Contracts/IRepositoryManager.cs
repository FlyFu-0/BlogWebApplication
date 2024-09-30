using Contracts.ModelsInterfaces;
using Repository.ModelsRepository;

namespace Contracts;

public interface IRepositoryManager
{
	IPostRepository Post { get; }
	ITagRepository Tag { get; }
	ILikeRepository Like { get; }
	ICommentRepository Comment { get; }
	IUserRepository User { get; }

	void Save();
}
