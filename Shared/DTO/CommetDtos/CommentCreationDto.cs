using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.CommetDtos;

public record CommentCreationDto
{
	[Required(ErrorMessage = "Content is a required field.")]
	public string? Content { get; init; }
	public Guid? PostId { get; init; }
	public string? UserId { get; init; }
}