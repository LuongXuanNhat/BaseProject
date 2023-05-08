using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTable_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Locations",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "46190570-5899-4c70-bc0d-e135344aa8a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c588f02a-a445-4741-a428-12501294b50f", "AQAAAAEAACcQAAAAEPrp+EGMMqE1lALLhN0AytTkxGQRkCau/xwq2kCcmxgWOEvXPaV9VHhB+bGaBK2fsQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "ShortName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "063e74a2-b653-4f7d-ac86-72e9d7d13922");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb2d8ee9-94f5-45db-8d37-9597d02563e0", "AQAAAAEAACcQAAAAEObwAoUUqTZtfNF8J6tMvdYW9gT8sqwHt/YkYQzC1ifDNlgEk+cYCsQZRyeqrbaQJw==" });
        }
    }
}
