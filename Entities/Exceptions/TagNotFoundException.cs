namespace Entities.Exceptions;

public class TagNotFoundException : NotFoundException
{
	public TagNotFoundException(Guid tagId) : base($"The tag with id:{tagId} doesn't not exist.")
	{
	}

	public TagNotFoundException(string tagIds) : base($"The tags with id:{tagIds} doesn't not exist.")
	{
	}
}
