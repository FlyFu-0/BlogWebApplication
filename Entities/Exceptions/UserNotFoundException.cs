namespace Entities.Exceptions;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(string userId) : base($"The user with id:{userId} doesn't not exist.")
	{
	}
}
