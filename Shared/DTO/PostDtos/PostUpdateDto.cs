namespace Shared.DTO.PostDtos;

public record PostUpdateDto
{
	public string? Title { get; init; }
	public string? Content { get; init; }
	public List<Guid>? TagIds { get; init; }
}