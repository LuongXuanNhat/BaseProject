using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class delete_attr_FK_Precomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_PreCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PreCommentId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "c8ba6b68-14ba-4e4a-b7ed-22390b296a62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "dcd1503c-ae64-4a1f-8b0a-43ae6556b58a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32fa3e77-23aa-4af4-b3b8-3895201c2e4b", "AQAAAAEAACcQAAAAEL5F0tL+7a7cbZFZZIdCGeYl2jqttJuwTtUEbrJ4PVBu8WbdYy63r6PwoYbbfnpAaA==" });

            //migrationBuilder.UpdateData(
            //    table: "Notifications",
            //    keyColumn: "NotificationId",
            //    keyValue: 1,
            //    column: "Date",
            //    value: new DateTime(2023, 6, 7, 13, 23, 36, 511, DateTimeKind.Local).AddTicks(3659));

            //migrationBuilder.UpdateData(
            //    table: "Notifications",
            //    keyColumn: "NotificationId",
            //    keyValue: 2,
            //    column: "Date",
            //    value: new DateTime(2023, 6, 7, 13, 23, 36, 511, DateTimeKind.Local).AddTicks(3671));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "f645daa2-3a2e-4e0f-bb5a-334ae1c0cc02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "711d31fa-d9b1-493a-9a94-429ddd8db9b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28255b1f-98ec-4902-bd7b-d8724a233c32", "AQAAAAEAACcQAAAAEAXDZ9BD6Ot90Iy4JsAphGDOmgRAmvYaUsjU3fPybW9aquorR5aSrruJHM2IBzRt2Q==" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 6, 7, 8, 51, 21, 531, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 6, 7, 8, 51, 21, 531, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PreCommentId",
                table: "Comments",
                column: "PreCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_PreCommentId",
                table: "Comments",
                column: "PreCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
