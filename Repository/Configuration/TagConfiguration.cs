using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
	public void Configure(EntityTypeBuilder<Tag> builder)
	{
		builder.HasData(
			new Tag
			{
				Id = new Guid("80484fb0-f6ca-40ae-81a0-8cd788d9f084"),
				Name = "TestTag1",
			},
			new Tag
			{
				Id = new Guid("03ea7b96-ef91-4278-bb6e-fbde888775eb"),
				Name = "TestTag2",
			},
			new Tag
			{
				Id = new Guid("68cb575c-9247-4973-81bc-e5e197711359"),
				Name = "TestTag3",
			}
		);
	}
}
