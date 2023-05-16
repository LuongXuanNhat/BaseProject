using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "d234decb-bd0d-447e-af53-6e5136f7e0aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"), "1462744d-a8b8-4d18-8eaa-a8f7a54ea147", "User Role", "user", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c086034-3ba0-43bb-8ab5-18d02d73777c", "AQAAAAEAACcQAAAAEEBlsyE+6JkGJ7zTYSLNTjFRz2KikzEug0Giw58VyKZfO1Tl3leO0AQ1GnmuFC4J9g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "38947cea-3c7a-4be2-b278-1bf9de577073");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7667cb3b-86fe-4958-9d3c-b199c7be707e", "AQAAAAEAACcQAAAAEMCFs8UzUh2oTRBrDtIcrU3d8W51wVCTpNCv+IVz15op5J2Zk0ALkPN6SZJ25U6CQQ==" });
        }
    }
}
