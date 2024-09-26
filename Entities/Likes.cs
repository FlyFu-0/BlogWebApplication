using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Like
{
	[Column("LikeId")]
	public Guid Id { get; set; }

	public DateTime CreatedAt { get; set; }

	[ForeignKey(nameof(Post))]
	public Guid PostId { get; set; }
	public Post? Post { get; set; }

	//[ForeignKey(nameof(User))]
	public Guid UserId { get; set; }
	//public User? User { get; set; }

}
