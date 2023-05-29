using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddData_CateLocation_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "CategoriesLocations",
                columns: new[] { "CategoriesId", "LocationId", "Description", "Id" },
                values: new object[,]
                {
                    { 1, 100, null, 3 },
                    { 1, 102, null, 6 },
                    { 1, 103, null, 8 },
                    { 1, 111, null, 23 },
                    { 1, 116, null, 28 },
                    { 1, 119, null, 34 },
                    { 1, 120, null, 35 },
                    { 1, 123, null, 40 },
                    { 1, 126, null, 46 },
                    { 1, 131, null, 56 },
                    { 1, 132, null, 58 },
                    { 1, 133, null, 63 },
                    { 1, 135, null, 69 },
                    { 1, 140, null, 79 },
                    { 1, 142, null, 82 },
                    { 1, 148, null, 97 },
                    { 1, 151, null, 107 },
                    { 1, 152, null, 109 },
                    { 1, 153, null, 112 },
                    { 1, 154, null, 116 },
                    { 1, 155, null, 118 },
                    { 1, 156, null, 120 },
                    { 1, 157, null, 123 },
                    { 1, 158, null, 124 },
                    { 2, 103, null, 9 },
                    { 2, 104, null, 14 },
                    { 2, 109, null, 19 },
                    { 2, 118, null, 31 },
                    { 2, 123, null, 41 },
                    { 2, 125, null, 43 },
                    { 2, 126, null, 47 },
                    { 2, 128, null, 49 },
                    { 2, 129, null, 51 },
                    { 2, 131, null, 57 },
                    { 2, 132, null, 59 },
                    { 2, 133, null, 64 },
                    { 2, 135, null, 70 },
                    { 2, 136, null, 72 },
                    { 2, 137, null, 76 },
                    { 2, 142, null, 83 },
                    { 2, 143, null, 87 },
                    { 2, 144, null, 89 },
                    { 2, 147, null, 94 },
                    { 2, 148, null, 95 },
                    { 2, 149, null, 98 },
                    { 2, 151, null, 115 },
                    { 2, 152, null, 110 },
                    { 2, 153, null, 114 },
                    { 2, 168, null, 126 },
                    { 3, 100, null, 4 },
                    { 3, 103, null, 10 },
                    { 3, 105, null, 15 },
                    { 3, 109, null, 20 },
                    { 3, 110, null, 21 },
                    { 3, 118, null, 32 },
                    { 3, 120, null, 36 },
                    { 3, 121, null, 38 },
                    { 3, 125, null, 44 },
                    { 3, 126, null, 45 },
                    { 3, 127, null, 48 },
                    { 3, 129, null, 52 },
                    { 3, 130, null, 55 },
                    { 3, 132, null, 60 },
                    { 3, 133, null, 65 },
                    { 3, 136, null, 71 },
                    { 3, 138, null, 78 },
                    { 3, 141, null, 81 },
                    { 3, 142, null, 84 },
                    { 3, 143, null, 88 },
                    { 3, 144, null, 90 },
                    { 3, 146, null, 91 },
                    { 3, 147, null, 93 },
                    { 3, 148, null, 96 },
                    { 3, 149, null, 99 },
                    { 3, 150, null, 106 },
                    { 3, 151, null, 108 },
                    { 3, 153, null, 113 },
                    { 3, 154, null, 117 },
                    { 3, 155, null, 119 },
                    { 3, 156, null, 121 },
                    { 3, 157, null, 122 },
                    { 3, 158, null, 125 },
                    { 3, 168, null, 127 },
                    { 4, 110, null, 22 },
                    { 4, 120, null, 37 },
                    { 4, 129, null, 53 },
                    { 4, 136, null, 73 },
                    { 4, 142, null, 85 },
                    { 5, 103, null, 11 },
                    { 8, 101, null, 5 },
                    { 8, 112, null, 25 },
                    { 8, 128, null, 50 },
                    { 8, 137, null, 75 },
                    { 9, 103, null, 12 },
                    { 9, 109, null, 18 },
                    { 9, 118, null, 105 },
                    { 9, 120, null, 104 },
                    { 9, 132, null, 103 },
                    { 9, 136, null, 102 },
                    { 9, 142, null, 101 },
                    { 9, 149, null, 100 },
                    { 10, 107, null, 16 },
                    { 10, 115, null, 27 },
                    { 10, 124, null, 42 },
                    { 10, 130, null, 54 },
                    { 10, 138, null, 77 },
                    { 10, 141, null, 80 },
                    { 10, 147, null, 92 },
                    { 11, 108, null, 17 },
                    { 11, 114, null, 26 },
                    { 11, 134, null, 68 },
                    { 12, 122, null, 39 },
                    { 12, 132, null, 61 },
                    { 12, 133, null, 67 },
                    { 14, 104, null, 15 },
                    { 15, 24, null, 2 },
                    { 16, 118, null, 33 },
                    { 17, 117, null, 30 },
                    { 18, 24, null, 1 },
                    { 18, 104, null, 13 },
                    { 19, 102, null, 7 },
                    { 19, 111, null, 24 },
                    { 19, 116, null, 29 },
                    { 19, 132, null, 62 },
                    { 19, 133, null, 66 },
                    { 19, 136, null, 74 },
                    { 19, 142, null, 86 },
                    { 19, 152, null, 111 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 100 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 102 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 103 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 111 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 116 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 119 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 120 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 123 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 126 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 131 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 133 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 135 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 140 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 148 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 151 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 152 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 153 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 154 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 155 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 156 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 157 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 1, 158 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 103 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 104 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 109 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 118 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 123 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 125 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 126 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 128 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 129 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 131 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 133 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 135 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 136 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 137 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 143 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 144 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 147 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 148 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 149 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 151 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 152 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 153 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 2, 168 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 100 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 103 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 105 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 109 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 110 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 118 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 120 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 121 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 125 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 126 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 127 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 129 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 130 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 133 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 136 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 138 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 141 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 143 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 144 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 146 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 147 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 148 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 149 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 150 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 151 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 153 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 154 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 155 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 156 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 157 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 158 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 3, 168 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 4, 110 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 4, 120 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 4, 129 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 4, 136 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 4, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 5, 103 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 8, 101 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 8, 112 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 8, 128 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 8, 137 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 103 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 109 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 118 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 120 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 136 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 9, 149 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 107 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 115 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 124 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 130 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 138 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 141 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 10, 147 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 11, 108 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 11, 114 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 11, 134 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 12, 122 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 12, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 12, 133 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 14, 104 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 15, 24 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 16, 118 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 17, 117 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 18, 24 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 18, 104 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 102 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 111 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 116 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 132 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 133 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 136 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 142 });

            migrationBuilder.DeleteData(
                table: "CategoriesLocations",
                keyColumns: new[] { "CategoriesId", "LocationId" },
                keyValues: new object[] { 19, 152 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "3bdbeec0-ca3e-492b-962d-9502c1077eef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "49dc234b-4845-4b41-b80d-78da1f274cb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec935125-fe15-4ecc-88c8-ba989b568767", "AQAAAAEAACcQAAAAEIIRJwtp5d7/H2dHonlZSB3BxEqFtcP3nixrdvAh2U+vpm6kyQ/69frATpCEdPxDFg==" });
        }
    }
}
