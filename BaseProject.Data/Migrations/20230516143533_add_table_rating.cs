using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_table_rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationsDetails",
                table: "LocationsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "RatingPost");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Images",
                newName: "LocationsDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PostId",
                table: "Images",
                newName: "IX_Images_LocationsDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "RatingPost",
                newName: "IX_RatingPost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_PostId",
                table: "RatingPost",
                newName: "IX_RatingPost_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LocationsDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationsDetails",
                table: "LocationsDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingPost",
                table: "RatingPost",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RatingLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationDetailId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingLocations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatingLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "7db01615-3f32-4262-b58a-30b2a4f9243e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c94e4867-96cd-4451-9f0f-17d17a356c81", "AQAAAAEAACcQAAAAEFM49MIoVVvTAq6wvKRXuWjKTm+QC0oaD1T6PspM9PEaPdhjk+CETZnqxiHrFqgQrg==" });

            migrationBuilder.CreateIndex(
                name: "IX_LocationsDetails_LocationId",
                table: "LocationsDetails",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LocationId",
                table: "Images",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingLocations_LocationId",
                table: "RatingLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingLocations_UserId",
                table: "RatingLocations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_LocationsDetails_LocationsDetailId",
                table: "Images",
                column: "LocationsDetailId",
                principalTable: "LocationsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Locations_LocationId",
                table: "Images",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingPost_AspNetUsers_UserId",
                table: "RatingPost",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RatingPost_Posts_PostId",
                table: "RatingPost",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_LocationsDetails_LocationsDetailId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Locations_LocationId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingPost_AspNetUsers_UserId",
                table: "RatingPost");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingPost_Posts_PostId",
                table: "RatingPost");

            migrationBuilder.DropTable(
                name: "RatingLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationsDetails",
                table: "LocationsDetails");

            migrationBuilder.DropIndex(
                name: "IX_LocationsDetails_LocationId",
                table: "LocationsDetails");

            migrationBuilder.DropIndex(
                name: "IX_Images_LocationId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingPost",
                table: "RatingPost");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "RatingPost",
                newName: "Ratings");

            migrationBuilder.RenameColumn(
                name: "LocationsDetailId",
                table: "Images",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_LocationsDetailId",
                table: "Images",
                newName: "IX_Images_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingPost_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingPost_PostId",
                table: "Ratings",
                newName: "IX_Ratings_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LocationsDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationsDetails",
                table: "LocationsDetails",
                columns: new[] { "LocationId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "2d109216-abcb-4b26-b4d3-925fe551dd16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6863e82d-3017-454e-8fd6-633ae1d46507", "AQAAAAEAACcQAAAAEGPVAAPOG2Wd+LmbLsJzjhDoRGDQ6GPSOAzvbvTZrPjs/GCVQ1AUH34UAX9TvleQEA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Posts_PostId",
                table: "Ratings",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
