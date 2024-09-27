using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "b461be31-41d3-4072-8a54-0b21dc018672", "Test@test.com", false, false, null, null, null, null, null, false, "a628af08-8bb5-40e4-91e9-202f66f88c61", false, "Test" },
                    { "2", 0, "5c6cec50-a989-4536-b003-4e3acbe60a86", "Test2@test.com", false, false, null, null, null, null, null, false, "fba6beb9-35d7-45a3-84ec-0374410704be", false, "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreatedAt", "LikesCount", "Title", "UpdatedAt", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(150), 0, "TestTitle3", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(151), "2", 0 },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(133), 0, "TestTitle1", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(137), "1", 0 },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(145), 0, "TestTitle2", new DateTime(2024, 9, 27, 15, 58, 32, 691, DateTimeKind.Utc).AddTicks(146), "1", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
