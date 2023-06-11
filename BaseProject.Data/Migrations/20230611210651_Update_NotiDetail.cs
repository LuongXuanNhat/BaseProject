using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_NotiDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoticeDetails",
                table: "NoticeDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoticeDetails_NotificationId",
                table: "NoticeDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NoticeDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoticeDetails",
                table: "NoticeDetails",
                columns: new[] { "NotificationId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "a28f8d2f-52e5-421c-b50d-f862d0dcf31c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "6dc70b8c-88b2-4331-977f-33b6ac6198c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccc35209-0513-46a8-8aea-cf764003f89a", "AQAAAAEAACcQAAAAEMPqdcLaqkx23rCg5eR7WVKTsAVqedOa1wH3ZmvBEdmXU8wiJG7iNYNt3t3hxJfHfQ==" });
        }
    }
}
