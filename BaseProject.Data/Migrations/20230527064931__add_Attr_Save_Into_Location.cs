using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class _add_Attr_Save_Into_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Saveds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "6b9f11fb-9f9e-4854-854a-91fb2bf2a722");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "21cdc038-b63b-4351-bc74-40786e5241ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "419eb390-d780-4e06-8657-8f09e4b5c9a2", "AQAAAAEAACcQAAAAEOTqBC3Z46wNSTU9SZgjT6oK14oBFWLY/5Efmt14xX9RyoPEDF3Ue9Z5FGILRuKGpQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Saveds_LocationId",
                table: "Saveds",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saveds_Locations_LocationId",
                table: "Saveds",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saveds_Locations_LocationId",
                table: "Saveds");

            migrationBuilder.DropIndex(
                name: "IX_Saveds_LocationId",
                table: "Saveds");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Saveds");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "34261a68-3f1a-4ef5-8138-12227cec6aea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "f9fba264-b8ac-494b-bfb2-2ad28ba49f8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2505cc4-9f10-4172-8e17-bb6a0a3298d7", "AQAAAAEAACcQAAAAEE2Wdz7JbJWAoIzGrL1Q/d5XBO8E6Rb/5+oaBoFiFI34rkQob/oFgL2zE25GdQAQGA==" });
        }
    }
}
