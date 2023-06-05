using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStringLength_COntent_4000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
           name: "Content",
           table: "LocationsDetails",
           maxLength: 4000,
           nullable: true,
           oldClrType: typeof(string),
           oldType: "nvarchar(1000)",
           oldMaxLength: 1000,
           oldNullable: true);
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "0013b858-792a-428c-aa55-06aca01ddc75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "d5a73a0a-c9bc-43f1-8e07-569474627a3f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c98bc957-55a9-41ae-a962-7141b67b8330", "AQAAAAEAACcQAAAAELAoR4NzjxD3uitbnibPRvUN19iUqSqp0La85AQlaaqW1fNUnDrlgT2Kl/+SP/X3MA==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 4, 14, 16, 56, 851, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 4, 14, 16, 56, 851, DateTimeKind.Local).AddTicks(8320));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "b301b6ca-1568-410a-a07b-5ec20995b6d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "625b6b6b-1383-4bf2-b3c4-b07bb8bd8083");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5b8ac07-7299-4fa5-b335-2ecce23b7fa3", "AQAAAAEAACcQAAAAEHL0JW4sViEMy864NhPrWkJDWDQ2hVOJiYca9gY0O8Ckcnl0NNJVpIbtGNhsPsYvkA==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 2, 12, 45, 9, 923, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 2, 12, 45, 9, 923, DateTimeKind.Local).AddTicks(6014));
        }
    }
}
