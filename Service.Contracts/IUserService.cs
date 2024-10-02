using Shared.DTO.UserDtos;

namespace Service.Contracts;

public interface IUserService
{
	Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);

	Task<UserDto> GetUserAsync(string Id, bool trackChanges);
}
