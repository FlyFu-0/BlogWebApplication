using Entities;

namespace Contracts.ModelsInterfaces;

public interface IUserRepository
{
	IEnumerable<User> GetAllUsers(bool trackChanges);

	User GetUser(string userId, bool trackChanges);
}
