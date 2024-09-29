using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebApplication.Migrations
{
	/// <inheritdoc />
	public partial class InitialTagTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{

			migrationBuilder.InsertData(
				table: "Tags",
				columns: new[] { "TagId", "Name" },
				values: new object[,]
				{
					{ new Guid("03ea7b96-ef91-4278-bb6e-fbde888775eb"), "TestTag2" },
					{ new Guid("68cb575c-9247-4973-81bc-e5e197711359"), "TestTag3" },
					{ new Guid("80484fb0-f6ca-40ae-81a0-8cd788d9f084"), "TestTag1" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}
