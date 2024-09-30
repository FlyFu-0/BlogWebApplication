using Contracts.ModelsInterfaces;
using Entities;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
	public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public IEnumerable<User> GetAllUsers(bool trackChanges)
		=> FindAll(trackChanges).ToList();

	public User GetUser(string userId, bool trackChanges)
		=> FindByCondition(u => u.Id.Equals(userId), trackChanges)
			.SingleOrDefault();
}
