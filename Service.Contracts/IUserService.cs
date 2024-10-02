using Shared.DTO.UserDtos;

namespace Service.Contracts;

public interface IUserService
{
	Task<IEnumerable<UserDto>> GetAllUsers(bool trackChanges);

	Task<UserDto> GetUser(string Id, bool trackChanges);
}
