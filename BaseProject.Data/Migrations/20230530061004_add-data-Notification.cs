using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddataNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "3a527a0f-6695-4303-8567-46d9d585bc11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "55fa0312-8838-4e86-a7af-1b86e1946ccc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "de815c58-7151-41a3-aeca-44858bdf1604", "AQAAAAEAACcQAAAAENci7GOwP6jkQl+/emORDtSch3dOUHbDxVh/4MNvwstIFbAtlrr+gYwoFkeMqQD+Hw==" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "Date", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 30, 13, 10, 4, 508, DateTimeKind.Local).AddTicks(8099), "Thông báo hệ thống" },
                    { 2, new DateTime(2023, 5, 30, 13, 10, 4, 508, DateTimeKind.Local).AddTicks(8111), "Tương tác" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "75419909-3856-4234-abdf-ddb30fe1b9b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "c72e44d1-f716-46ea-a730-28c65a62a751");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e6d01e1-a06f-4b99-8ad7-db5975562682", "AQAAAAEAACcQAAAAEEqaXORB+Z8F3Bc3kTYtOEGpLQlUCRDKrAHT25fEhczSvMN44ZNjWNThltXVR8+JEQ==" });
        }
    }
}
