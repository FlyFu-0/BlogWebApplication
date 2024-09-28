using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Tag
{
	[Column("TagId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Name is a required field.")]
	[MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
	public string? Name { get; set; }

	public ICollection<Post> Post { get; set; } = new List<Post>();
}
