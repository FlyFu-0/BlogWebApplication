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

		builder.Entity<Post>()
			.HasMany(p => p.Tags)
			.WithMany(t => t.Post)
			.UsingEntity<Dictionary<string, object>>(
				"PostTag",
				pt => pt.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
				pt => pt.HasOne<Post>().WithMany().HasForeignKey("PostId")
			);

		//builder.Entity<Dictionary<string, object>>("PostTag").HasData(
	//		new Dictionary<string, object> { ["PostId"] = "80abbca8-664d-4b20-b5de-024705497d4a", ["TagId"] = "03ea7b96-ef91-4278-bb6e-fbde888775eb" }
		//	);

		builder.ApplyConfiguration(new UserConfiguration());
		builder.ApplyConfiguration(new PostConfiguration());
		builder.ApplyConfiguration(new TagConfiguration());
	}

	public DbSet<Post>? Posts { get; set; }
	public DbSet<Like>? Likes { get; set; }
	public DbSet<Tag>? Tags { get; set; }
	public DbSet<Comment>? Comments { get; set; }
}
