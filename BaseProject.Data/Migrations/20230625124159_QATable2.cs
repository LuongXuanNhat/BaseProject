using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class QATable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAndAnswers_Posts_PostId",
                table: "QuestionAndAnswers");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "QuestionAndAnswers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAndAnswers_PostId",
                table: "QuestionAndAnswers",
                newName: "IX_QuestionAndAnswers_LocationId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "39ca5034-beb5-4542-8dd3-af70ab3848d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "18c79897-23da-4dc3-80b8-d86c604f4d04");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "36456097-6302-4a38-a85b-19be497978e8", "AQAAAAEAACcQAAAAEF8OrAYRaGoSeWw+6l/tMHqGgwJVblECQKqPXLCvz4J+68tHtGh5CHRShL1RWNTsFw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAndAnswers_Locations_LocationId",
                table: "QuestionAndAnswers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAndAnswers_Locations_LocationId",
                table: "QuestionAndAnswers");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "QuestionAndAnswers",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAndAnswers_LocationId",
                table: "QuestionAndAnswers",
                newName: "IX_QuestionAndAnswers_PostId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "0a1d473a-2348-4f8f-ac34-470a96b38ef3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "59b5b3f4-26d2-4f73-9e12-e94c8a6f7ea1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32cf249d-48e0-4bfb-bba0-d842db62fb1b", "AQAAAAEAACcQAAAAEHPeSil23hvQq5OJSUqy2YtwX7ZDF26EJ/gVqtohhzSZVGW2jJx6GQTP0OCkh0ah4g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAndAnswers_Posts_PostId",
                table: "QuestionAndAnswers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
