using Entities;

namespace Contracts.ModelsInterfaces;

public interface IUserRepository
{
	Task<IEnumerable<User>> GetAllUsers(bool trackChanges);

	Task<User> GetUser(string userId, bool trackChanges);
}
