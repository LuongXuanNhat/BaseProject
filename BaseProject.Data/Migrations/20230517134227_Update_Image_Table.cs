using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Image_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "NumericalOrder",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "8c3c05ea-bba4-411c-ad3d-e8cf64c6caad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "ed5a3644-b577-408b-b979-fe4c0e257d90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29cb008e-a579-441b-a93b-684486a2165d", "AQAAAAEAACcQAAAAENY7LNKJ1PtLsTYAI1xRsuCx0rO7ty0H5mWWEAE6p44uUCneKxECncdGhTGxCrx6ZQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumericalOrder",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "d234decb-bd0d-447e-af53-6e5136f7e0aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "1462744d-a8b8-4d18-8eaa-a8f7a54ea147");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c086034-3ba0-43bb-8ab5-18d02d73777c", "AQAAAAEAACcQAAAAEEBlsyE+6JkGJ7zTYSLNTjFRz2KikzEug0Giw58VyKZfO1Tl3leO0AQ1GnmuFC4J9g==" });
        }
    }
}
