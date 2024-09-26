using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Post
{
	[Column("PostId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Title is a required field.")]
	[MaxLength(60, ErrorMessage = "Maximum length for the Title is 60 characters.")]
	public string Title { get; set; }


	[Required(ErrorMessage = "Content is a required field.")]
	public string? Content { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }

	public int LikesCount { get; set; }
	public int ViewsCount { get; set; }

	//[ForeignKey(nameof(User))]
	public Guid AuthorId { get; set; }
	//public User? User { get; set; }
}
