using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_table_rating1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "98ffb499-8403-4afa-be24-6acd86b9cc4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "881d8ebe-3fc9-43cf-8c78-47659c0f7771", "AQAAAAEAACcQAAAAEGxZmrt0+h9a1MpN5gHGqztTg+Kfy2j1GG7E6n7mVT6LWP8HsOLg/5sNaxbEET6NIg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "7db01615-3f32-4262-b58a-30b2a4f9243e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c94e4867-96cd-4451-9f0f-17d17a356c81", "AQAAAAEAACcQAAAAEFM49MIoVVvTAq6wvKRXuWjKTm+QC0oaD1T6PspM9PEaPdhjk+CETZnqxiHrFqgQrg==" });
        }
    }
}
