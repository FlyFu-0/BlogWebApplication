using Entities;
using Repository.ModelsRepository;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
	public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}
}
