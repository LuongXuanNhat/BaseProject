using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_NotiDetail_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
               name: "PK_NoticeDetails",
               table: "NoticeDetails");



            migrationBuilder.AddColumn<int>(
        name: "Id",
        table: "NoticeDetails",
        nullable: false,
        defaultValue: 0)
        .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
            name: "PK_NoticeDetails",
            table: "NoticeDetails",
            column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "a18d1079-3173-4d36-8508-d36d4069c0c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "19e16e9c-34a1-46c1-9265-7d884ddd8dcc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1228f547-485b-4019-aa04-2b6a10451d99", "AQAAAAEAACcQAAAAEFk6sqISqwGG57Q4iHBhKZqCBncU/2pjzB+6X8M7nKik2Belskv7c3MuTsaZS4iEHQ==" });
        }
    }
}
