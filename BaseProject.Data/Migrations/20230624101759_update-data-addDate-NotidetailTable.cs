using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedataaddDateNotidetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "NoticeDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Followings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "5cd1c98e-c868-4a3b-8f33-b38cdb90bcbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "d16cdba6-e52b-43d2-ad1b-be62fa0fcba4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2dcc1e92-e231-4b5e-8717-30c77f038c13", "AQAAAAEAACcQAAAAENXCIxNeaR3LeIlinDQK2qE6LMo6lyenUA1chJwA87y9zUef1Ag8eQJIlKdiBk5tRw==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Title",
                value: "Thông báo tương tác");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "NoticeDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Followings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "1a1ea4d5-1ae0-40b3-bc99-d18795c65f0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "c6b9c36b-f776-4718-b540-a8e9fba249eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9db0e7e6-e491-46bd-b9c9-c817a2d98241", "AQAAAAEAACcQAAAAEIhXeosTVZO4AQlEIYByydMfEjqKXPhah4VnalQG8VL2FwgiqSFP1WL202V4/rZp6A==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Title",
                value: "Tương tác");
        }
    }
}
