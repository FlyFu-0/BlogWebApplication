using Shared.DTO.UserDtos;

namespace Service.Contracts;

public interface IUserService
{
	IEnumerable<UserDto> GetAllUsers(bool trackChanges);

	UserDto GetUser(string Id, bool trackChanges);
}
