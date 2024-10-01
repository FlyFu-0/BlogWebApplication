namespace Entities.Exceptions;

public class TagNotFoundException : NotFoundException
{
	public TagNotFoundException(Guid tagId) : base($"The tag with id:{tagId} doesn't not exist.")
	{
	}
}
