using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
	public RepositoryContext(DbContextOptions options) : base(options)
	{ }

	public DbSet<Post>? Posts { get; set; }
	public DbSet<Like>? Likes { get; set; }
	public DbSet<Tag>? Tags { get; set; }
	public DbSet<PostTag>? PostTags { get; set; }
	public DbSet<Comment>? Comments { get; set; }
}
