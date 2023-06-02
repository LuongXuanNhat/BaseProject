using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saveds_Locations_LocationId",
                table: "Saveds");

            migrationBuilder.DropForeignKey(
                name: "FK_Saveds_Posts_PostId",
                table: "Saveds");

            migrationBuilder.DropIndex(
                name: "IX_Saveds_LocationId",
                table: "Saveds");

            migrationBuilder.DropIndex(
                name: "IX_Saveds_PostId",
                table: "Saveds");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Saveds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Saveds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Saveds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Saveds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "e2974ed5-78a7-4cb4-af37-e40a7fa76340");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "170b69f4-13f5-4e4c-9fc6-1d9e07f18372");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "726356b4-bd15-4686-98e0-c5aa57ec0d2d", "AQAAAAEAACcQAAAAEDMCCa6u8/PrKRQNUkM4VVCmOLrZbk4x+ltY/MOCz8PZZOCx5dORQc2Jv7+zpT7gDg==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 1, 10, 9, 30, 421, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 1, 10, 9, 30, 421, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.CreateIndex(
                name: "IX_Saveds_LocationId",
                table: "Saveds",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Saveds_PostId",
                table: "Saveds",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saveds_Locations_LocationId",
                table: "Saveds",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saveds_Posts_PostId",
                table: "Saveds",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
