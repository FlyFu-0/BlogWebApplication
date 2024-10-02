using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.PostDtos;

public record PostUpdateDto
{
	[Required(ErrorMessage = "Title is a required field.")]
	[MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
	public string? Title { get; init; }
	[Required(ErrorMessage = "Content is a required field.")]
	public string? Content { get; init; }
	public List<Guid>? TagIds { get; init; }
	public string? UserId { get; init; }
}