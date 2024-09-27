using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Comment
{
	[Column("CommentId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Content is a required field.")]
	public string? Content { get; set; }

	public DateTime CreatedAt { get; set; }

	[ForeignKey(nameof(User))]
	public string? UserId { get; set; }
	public User? User { get; set; }

	[ForeignKey(nameof(Post))]
	public Guid PostId { get; set; }
	public Post? Post { get; set; }
}
