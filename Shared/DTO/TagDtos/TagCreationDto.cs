using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.TagDtos;

public record TagCreationDto
{
	[Required(ErrorMessage = "Name is a required field.")]
	[MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
	public string? Name { get; set; }
}
