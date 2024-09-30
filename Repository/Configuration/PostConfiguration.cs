using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.HasData(
			new Post
			{
				Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
				Title = "TestTitle1",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				LikesCount = 0,
				ViewsCount = 0,
				UserId = "1",
			},
			new Post
			{
				Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
				Title = "TestTitle2",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				LikesCount = 0,
				ViewsCount = 0,
				UserId = "1"
			},
			new Post
			{
				Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
				Title = "TestTitle3",
				Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
				LikesCount = 0,
				ViewsCount = 0,
				UserId = "2"
			}
		);
	}
}
