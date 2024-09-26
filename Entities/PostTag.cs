using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class PostTag
{
	[ForeignKey(nameof(Post))]
	public Guid PostId { get; set; }
	public Post? Post { get; set; }

	[ForeignKey(nameof(Tag))]
	public Guid TagId { get; set; }
	public Tag? Tag { get; set; }

}
