using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "8911d1c2-460d-43f3-a190-e1def7faa833");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "a31181d3-f6f0-4d01-98d2-1e8b2cfd9e1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "269662c3-2356-4d24-b1b1-8dcfbe0f2cc7", "AQAAAAEAACcQAAAAEJ8/RKPhqsgZwBbdW+5Mp7f7CDNU5Ea7peZbU4jJ7dix66hiVD5uNjcRBC5zQkVxLQ==" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "Name" },
                values: new object[,]
                {
                    { 100, "19B Phạm Ngọc Thạch, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán Cà Phê Trung Nguyên  " },
                    { 101, "9 Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", " Bảo tàng Hồ Chí Minh" },
                    { 102, "160 Pasteur, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", " Nhà hàng Ngon" },
                    { 103, "Thùy Vân, Thành phố Vũng Tàu , Việt Nam", "Bãi biển Vũng Tàu " },
                    { 104, " Cần Giờ ,TP. Hồ Chí Minh, Việt Nam", "Khu bảo tồn Thiên nhiên Cần Giờ " },
                    { 105, "101 Tôn Dật Tiên, Tân Phú, Quận 7 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Crescent Mall " },
                    { 106, "10-12 Đinh Tiên Hoàng, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Khoa học Xã hội và Nhân văn " },
                    { 107, "Trương Định, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Tao Đàn " },
                    { 108, "01 Công xã Paris, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà thờ Đức Bà Sài Gòn " },
                    { 109, "120 Xa lộ Hà Nội, Tân Phú, Quận 9 ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Suối Tiên " },
                    { 110, "7 Công trường Lam Sơn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hát Thành phố Hồ Chí Minh  " },
                    { 111, "138 Nguyễn Thị Minh Khai, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Ngon Xưa " },
                    { 112, " 97A Phó Đức Chính, Nguyễn Thái Bình, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Bảo tàng Mỹ thuật TP. Hồ Chí Minh  " },
                    { 113, "216 Võ Thị Sáu, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", " Trường Quốc tế Úc " },
                    { 114, "289 Hai Bà Trưng, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà thờ Tân Định " },
                    { 115, "108-120 Lê Duẩn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Khu công viên 30/4  " },
                    { 116, "233B Nguyễn Văn Cừ, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hàng Huế Cẩm " },
                    { 117, "565 Lạc Long Quân, Phường 10, Quận Tân Bình ,TP. Hồ Chí Minh, Việt Nam", "Chùa Giác Lâm " },
                    { 118, "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Văn Thánh " },
                    { 119, " 728 Võ Văn Kiệt, Phường 1, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hàng Làng Nướng Nam Bộ  " },
                    { 120, "1147 Bình Quới, Phường 28, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Bình Quới " },
                    { 121, " 59-61 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Liberty Citypoint " },
                    { 122, "Lê Lợi, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Chợ Bến Thành " },
                    { 123, "26 Lê Thị Riêng, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Huỳnh Hoa" },
                    { 124, "Phạm Văn Đồng, Phường 3, Quận Gò Vấp ,TP. Hồ Chí Minh, Việt Nam", "Công viên Gia Định " },
                    { 125, "30 Trần Hưng Đạo, Cầu Ông Lãnh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hát Kịch TP. Hồ Chí Minh  " },
                    { 126, " 14E1 Nguyễn Thị Minh Khai, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Cộng Cà Phê " },
                    { 127, "80 D2, Tổ 4, Phường 11, Quận Tân Bình ,TP. Hồ Chí Minh, Việt Nam", "Trung tâm Thể thao Rạch Miễu " },
                    { 128, "1 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Bảo tàng Lịch sử TP. Hồ Chí Minh " },
                    { 129, " Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Khu phố Tây Bùi Viện " },
                    { 130, "Đồng Khởi, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Lê Văn Tám " },
                    { 131, " 110 Cống Quỳnh, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Lẩu Bò Tòng Dương  " },
                    { 132, "11 Sư Vạn Hạnh, Phường 12, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Vạn Hạnh Mall " },
                    { 133, "720A Điện Biên Phủ, Phường 22, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Trung tâm mua sắm Vincom Center Landmark 81 " },
                    { 134, "01 Công xã Paris, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà thờ Đức Bà Sài Gòn " },
                    { 135, " 99 Nguyễn Huệ, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hàng Buffet Villa " },
                    { 136, "905A Hùng Vương, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Bửu Long " },
                    { 137, "97A Phó Đức Chính, Nguyễn Thái Bình, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Bảo tàng Mỹ thuật TP. Hồ Chí Minh " },
                    { 138, "23-25 Lê Thị Riêng, Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Lê Thị Riêng " },
                    { 139, "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Bách Khoa TP. Hồ Chí Minh " },
                    { 140, " 229 Đường 3/2, Phường 12, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hàng Hủ Tiếu Mỹ Tho 3 Miền " },
                    { 141, "Đại lộ Nguyễn Văn Linh, Phường 7, Quận 7 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Cá Mập " },
                    { 142, "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Văn Thánh Miếu Nổi  " },
                    { 143, "15 Nguyễn Thị Minh Khai, Phường Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê The Coffee House " },
                    { 144, "202 Lê Hồng Phong, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Khu vui chơi giải trí 7 viên ngọc rồng " },
                    { 145, "59C Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Kinh tế TP. Hồ Chí Minh " },
                    { 146, "ầng 5, Parkson Flemington, 184 Lê Đại Hành, Phường 15, Quận 11 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Cinemas " },
                    { 147, "3 Hòa Bình, Phường 3, Quận 11 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Văn hóa Đầm Sen " },
                    { 148, "14 Nguyễn Thị Minh Khai, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê The Coffee Bean & Tea Leaf  " },
                    { 149, " ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Đầm Sen " },
                    { 150, " ,TP. Hồ Chí Minh, Việt Nam", "176 Đường Hồng Lạc, Phường 10, Quận 11 " },
                    { 151, "157-159 Nguyễn Thị Minh Khai, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Highlands Coffee  " },
                    { 152, " 127 Trần Quốc Thảo, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Bánh Cuốn Tây Hồ  " },
                    { 153, "264A Nam Kỳ Khởi Nghĩa, Phường 8, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Trung Nguyên Legend Café " },
                    { 154, "80 Hoàng Hoa Thám, Phường 12, Tân Bình ,TP. Hồ Chí Minh, Việt Nam", "Start Cup Coffee " },
                    { 155, " 82 Võ Văn Tần, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Start Cup Coffee " },
                    { 156, "63 Nguyễn Huệ, Bến Nghé, Quận 1  ,TP. Hồ Chí Minh, Việt Nam", "Start Cup Coffee " },
                    { 157, " 190 Xô Viết Nghệ Tĩnh, Phường 21, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Start Cup Coffee " },
                    { 158, " 297 Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Start Cup Coffee " },
                    { 159, "280 An Dương Vương, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Sư phạm TP. Hồ Chí Minh " },
                    { 160, "2 Trường Sa, Phường 17, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Đại học Ngoại thương TP. Hồ Chí Minh " },
                    { 161, " 217 Hồng Bàng, Phường 11, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Y Dược TP. Hồ Chí Minh " },
                    { 162, "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Công nghệ Thông tin TP. Hồ Chí Minh " },
                    { 163, " 273 An Dương Vương, Phường 3, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Sài Gòn  " },
                    { 164, "202 Lê Văn Sỹ, Phường 10, Quận Phú Nhuận ,TP. Hồ Chí Minh, Việt Nam", "Đại học Văn Hiến  " },
                    { 165, "475A Điện Biên Phủ, Phường 25, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh (Cơ sở chính - SaiGon Campus) " },
                    { 166, " 2, đường Ung Văn Khiêm, Phường 25, Quận Bình Thạnh  ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh ( Cơ sở Ung Văn Khiêm)" },
                    { 167, "10/80C XL Hà Nội, Phường Tân Phú, Thủ Đức ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh  ( Thủ đức Campus )" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 167);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "43468bfe-6ea4-4ae0-9ebf-833269bd53b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "bb4bfe13-0d49-4972-bc96-4fbb3cfab53d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47b8dab0-511c-4b67-8b1f-0ceb4dc3ea69", "AQAAAAEAACcQAAAAEI9ssJkDODUhBkNWGrx2l7g4RIjoLv7gctZcWuaky15dG111A+Hh/Eo90TbZekOsJw==" });
        }
    }
}
