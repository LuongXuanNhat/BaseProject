using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_LocationDetail_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "GoWith",
                table: "LocationsDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "When",
                table: "LocationsDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoWith",
                table: "LocationsDetails");

            migrationBuilder.DropColumn(
                name: "When",
                table: "LocationsDetails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "6cc3603a-3a39-4b27-81c2-e650b81b3b26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26641d93-a063-4fa6-a5db-ceb217da6400", "AQAAAAEAACcQAAAAEHoS+hihcqf1JTdX9IerpszqLDTFBGDTKQBokDSoMPLMoFiOwpsjVoYVKePmW1CIMw==" });
        }
    }
}
