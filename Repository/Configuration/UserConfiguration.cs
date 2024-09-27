using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasData(
			new User
			{
				Id = "1",
				UserName = "Test",
				Email = "Test@test.com",
			},
			new User
			{
				Id = "2",
				UserName = "Test2",
				Email = "Test2@test.com",
			}
		);
	}
}
