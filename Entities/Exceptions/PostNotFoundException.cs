namespace Entities.Exceptions;

public class PostNotFoundException : NotFoundException
{
	public PostNotFoundException(Guid postId) : base($"The post with id:{postId} doesn't not exist.")
	{
	}
}
