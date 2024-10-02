using Entities;

namespace Contracts.ModelsInterfaces;

public interface IUserRepository
{
	Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);

	Task<User> GetUserAsync(string userId, bool trackChanges);
}
