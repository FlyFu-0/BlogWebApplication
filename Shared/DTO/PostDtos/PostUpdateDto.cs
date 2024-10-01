namespace Shared.DTO.PostDtos;

public record PostUpdateDto
{
	public string? Title;
	public string? Content;
	public List<Guid>? TagIds;
}