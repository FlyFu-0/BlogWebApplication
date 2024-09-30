using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DTO.UserDtos;

namespace Service;

public class UserService : IUserService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;

	public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
	{
		var users = _repository.User.GetAllUsers(trackChanges);
		var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

		return usersDto;
	}

	public UserDto GetUser(string Id, bool trackChanges)
	{
		var users = _repository.User.GetUser(Id, trackChanges);
		var userDto = _mapper.Map<UserDto>(users);

		return userDto;
	}
}
