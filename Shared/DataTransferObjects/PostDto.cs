namespace Shared.DataTransferObjects;

public record PostDto(Guid Id, string Title, string Content,
	int LikesCount, int ViewsCount, DateTime CreatedAt, DateTime UpdatedAt);
