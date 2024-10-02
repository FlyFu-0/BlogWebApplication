using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.CommetDtos;

public record CommentUpdateDto
{
	[Required(ErrorMessage = "Content is a required field.")]
	public string? Content { get; init; }
}
