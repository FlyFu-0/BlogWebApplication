using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
	public RepositoryContext(DbContextOptions options) : base(options)
	{ }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfiguration(new UserConfiguration());
		builder.ApplyConfiguration(new PostConfiguration());
	}

	public DbSet<Post>? Posts { get; set; }
	public DbSet<Like>? Likes { get; set; }
	public DbSet<Tag>? Tags { get; set; }
	public DbSet<PostTag>? PostTags { get; set; }
	public DbSet<Comment>? Comments { get; set; }
}
