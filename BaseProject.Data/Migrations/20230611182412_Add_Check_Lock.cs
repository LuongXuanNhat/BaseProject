using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Check_Lock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Check",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Check",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "ac5ecad7-91b1-4a1b-9af8-c469cf03069d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "72a636a2-091f-45be-aeff-3ffa8a865c83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e899af0d-699e-481a-93f6-c9a9c454393b", "AQAAAAEAACcQAAAAEF7qBUPMT1kIElI5g7G5rja8dOBgb0M0TqNnqQvEaBbz59idAR7QFuGSAdeg+OGxtQ==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 12, 1, 24, 12, 216, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 12, 1, 24, 12, 216, DateTimeKind.Local).AddTicks(9644));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Check",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Check",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "cae02778-3f96-4eab-b09d-68d8a3d6209f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "f6410dde-766d-44ec-b6af-923b672652a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fea656c0-f5b7-4fa7-bca3-e1da49ce6100", "AQAAAAEAACcQAAAAEFHAMjgb4frnrI5ULY/oy5iFufzpYCYpeezlx+bWmV8QyKpzEYZoZF05cHftvUIXNw==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 9, 21, 26, 43, 961, DateTimeKind.Local).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 9, 21, 26, 43, 961, DateTimeKind.Local).AddTicks(985));
        }
    }
}
