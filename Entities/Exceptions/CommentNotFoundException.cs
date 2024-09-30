namespace Entities.Exceptions;

public class CommentNotFoundException : NotFoundException
{
	public CommentNotFoundException(Guid commentId) : base($"The comment with id:{commentId} doesn't not exist.")
	{
	}
}
