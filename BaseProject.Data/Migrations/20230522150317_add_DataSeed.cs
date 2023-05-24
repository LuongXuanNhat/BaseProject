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
            migrationBuilder.AlterColumn<int>(
                name: "LocationsDetailId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575"),
                column: "ConcurrencyStamp",
                value: "d7ec2465-fbd9-4046-9e32-7ca709c67dd0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "544485b3-937c-4d07-82c9-ec1d12e9f170");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d043eab-c6e3-4ab9-b98d-56c4dc90497c", "AQAAAAEAACcQAAAAEP7C+rnPkdyBifoDuAADPVRwKAFLJS/udKgPReFBw4iuvR2KK3JJTWLmXSkPWgKS0Q==" });

            //migrationBuilder.InsertData(
            //    table: "Locations",
            //    columns: new[] { "LocationId", "Address", "Name" },
            //    values: new object[,]
            //    {
            //        { 100, "Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh, Việt Nam", "Công viên 23/9" },
            //        { 101, "9 Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", " Bảo tàng Hồ Chí Minh" },
            //        { 102, "160 Pasteur, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", " Nhà hàng Ngon" },
            //        { 103, "Đường Thùy Vân, Tp. Vũng Tàu, Việt Nam", "Bãi Thùy Vân (bãi Sau)" },
            //        { 104, "đường Rừng Sác, xã Long Hòa, huyện Cần Giờ, Thành phố Hồ Chí Minh, Việt Nam", "Rừng Sác" },
            //        { 105, "101 Tôn Dật Tiên, Tân Phú, Quận 7 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Crescent Mall " },
            //        { 106, "10-12 Đinh Tiên Hoàng, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Khoa học Xã hội và Nhân văn " },
            //        { 107, "Trương Định, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Tao Đàn " },
            //        { 108, "01 Công xã Paris, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà thờ Đức Bà Sài Gòn " },
            //        { 109, "120 Xa lộ Hà Nội, Tân Phú, Quận 9 ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Suối Tiên " },
            //        { 110, "7 Công trường Lam Sơn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hát Thành phố Hồ Chí Minh  " },
            //        { 111, "số 25 đường Học Lạc, phường 14, quận 5, thành phố Hồ Chí Minh, Việt Nam", "Nhà Thờ Cha Tam" },
            //        { 112, "87/8P Xuân Thới Thượng 6, xã Xuân Thới Đông, huyện Hóc Môn, thành phố Hồ Chí Minh, Việt Nam", "Công Viên Cá Koi Rinrin Park" },
            //        { 113, "216 Võ Thị Sáu, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", " Trường Quốc tế Úc " },
            //        { 114, "289 Hai Bà Trưng, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà thờ Tân Định " },
            //        { 115, "108-120 Lê Duẩn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Khu công viên 30/4  " },
            //        { 116, "233B Nguyễn Văn Cừ, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Công Viên Nước Lego Water Park" },
            //        { 117, "565 Lạc Long Quân, Phường 10, Quận Tân Bình ,TP. Hồ Chí Minh, Việt Nam", "Chùa Giác Lâm " },
            //        { 118, "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Văn Thánh " },
            //        { 119, " 728 Võ Văn Kiệt, Phường 1, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hàng Làng Nướng Nam Bộ  " },
            //        { 120, "1147 Bình Quới, Phường 28, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Bình Quới 1" },
            //        { 121, " 59-61 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Liberty Citypoint " },
            //        { 122, "Lê Lợi, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Chợ Bến Thành " },
            //        { 123, "26 Lê Thị Riêng, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Huỳnh Hoa" },
            //        { 124, "Phạm Văn Đồng, Phường 3, Quận Gò Vấp ,TP. Hồ Chí Minh, Việt Nam", "Công viên Gia Định " },
            //        { 125, "30 Trần Hưng Đạo, Cầu Ông Lãnh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Nhà hát Kịch TP. Hồ Chí Minh  " },
            //        { 126, " 14E1 Nguyễn Thị Minh Khai, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Cộng Cà Phê " },
            //        { 127, "Số 01 đường Hoa Phượng, phường 2, quận Phú Nhuận ,TP. Hồ Chí Minh, Việt Nam", "Trung tâm Thể thao Rạch Miễu " },
            //        { 128, "1 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Bảo tàng Lịch sử TP. Hồ Chí Minh " },
            //        { 129, " Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Phố đi bộ Bùi Viện " },
            //        { 130, "Đồng Khởi, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Lê Văn Tám " },
            //        { 131, "22A Bến Vân Đồn, Phường 12, Quận 4, Hồ Chí Minh, Việt Nam", "Cầu Mống" },
            //        { 132, "11 Sư Vạn Hạnh, Phường 12, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Vạn Hạnh Mall " },
            //        { 133, "720A Điện Biên Phủ, Phường 22, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Trung tâm mua sắm Vincom Center Landmark 81 " },
            //        { 134, "Ấp Phú Hiệp, xã Phú Mỹ Hưng, huyện Củ Chi, Tp. Hồ Chí Minh, Việt Nam", "Địa Đạo Củ Chi" },
            //        { 135, "Nằm giữa 3 đường: Võ Văn Tần, Phạm Ngọc Thạch và Trần Cao Vân, quận 3, TP Hồ Chí Minh, Việt Nam", "Hồ Con Rùa" },
            //        { 136, "905A Hùng Vương, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Bửu Long " },
            //        { 137, "97A Phó Đức Chính, Nguyễn Thái Bình, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Bảo tàng Mỹ thuật TP. Hồ Chí Minh " },
            //        { 138, "23-25 Lê Thị Riêng, Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Lê Thị Riêng " },
            //        { 139, "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Bách Khoa TP. Hồ Chí Minh " },
            //        { 140, "Đường 11,phường Long Thạnh Mỹ, Quận 9, Hồ Chí Minh, Việt Nam", "Khu Du Lịch Suối Mơ" },
            //        { 141, "7, 2 Hải Triều, Bến Nghé, Quận 1, Hồ Chí Minh, Việt Nam", "Tòa Tháp Bitexco" },
            //        { 142, "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Khu du lịch Văn Thánh Miếu Nổi  " },
            //        { 143, "15 Nguyễn Thị Minh Khai, Phường Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê The Coffee House " },
            //        { 144, "106 Võ Văn Kiệt, Phường 6, Quận 5, TP. Hồ Chí Minh, Việt Nam", "Công Viên Nước Đại Thế Giới" },
            //        { 145, "59C Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Kinh tế TP. Hồ Chí Minh " },
            //        { 146, "Tầng 5, Parkson Flemington, 184 Lê Đại Hành, Phường 15, Quận 11 ,TP. Hồ Chí Minh, Việt Nam", "Rạp chiếu phim CGV Cinemas " },
            //        { 147, "3 Hòa Bình, Phường 3, Quận 11 ,TP. Hồ Chí Minh, Việt Nam", "Công viên Văn hóa Đầm Sen " },
            //        { 148, "14 Nguyễn Thị Minh Khai, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê The Coffee Bean & Tea Leaf" },
            //        { 149, "Đường số 9, Khu đô thị Him Lam, Quận 7, Hồ Chí Minh, Việt Nam", "Bảo Tàng Tranh 3D Sài Gòn" },
            //        { 150, "Tân Phong, Quận 7, thành phố Hồ Chí Minh, Việt Nam", "Khu Đô Thị Phú Mỹ Hưng" },
            //        { 151, "157-159 Nguyễn Thị Minh Khai, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Highlands Coffee  " },
            //        { 152, " 127 Trần Quốc Thảo, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán ăn Bánh Cuốn Tây Hồ  " },
            //        { 153, "264A Nam Kỳ Khởi Nghĩa, Phường 8, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Quán cà phê Trung Nguyên Legend Café " },
            //        { 154, "80 Hoàng Hoa Thám, Phường 12, Tân Bình ,TP. Hồ Chí Minh, Việt Nam", "Star Cup Coffee " },
            //        { 155, " 82 Võ Văn Tần, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam", "Star Cup Coffee " },
            //        { 156, "63 Nguyễn Huệ, Bến Nghé, Quận 1  ,TP. Hồ Chí Minh, Việt Nam", "Star Cup Coffee " },
            //        { 157, " 190 Xô Viết Nghệ Tĩnh, Phường 21, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Star Cup Coffee " },
            //        { 158, " 297 Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam", "Star Cup Coffee " },
            //        { 159, "280 An Dương Vương, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Sư phạm TP. Hồ Chí Minh " },
            //        { 160, "2 Trường Sa, Phường 17, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Đại học Ngoại thương TP. Hồ Chí Minh " },
            //        { 161, " 217 Hồng Bàng, Phường 11, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Y Dược TP. Hồ Chí Minh " },
            //        { 162, "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Công nghệ Thông tin TP. Hồ Chí Minh " },
            //        { 163, " 273 An Dương Vương, Phường 3, Quận 5 ,TP. Hồ Chí Minh, Việt Nam", "Đại học Sài Gòn  " },
            //        { 164, "202 Lê Văn Sỹ, Phường 10, Quận Phú Nhuận ,TP. Hồ Chí Minh, Việt Nam", "Đại học Văn Hiến  " },
            //        { 165, "475A Điện Biên Phủ, Phường 25, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh (Cơ sở chính - SaiGon Campus) " },
            //        { 166, " 2, đường Ung Văn Khiêm, Phường 25, Quận Bình Thạnh  ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh ( Cơ sở Ung Văn Khiêm)" },
            //        { 167, "10/80C XL Hà Nội, Phường Tân Phú, Thủ Đức ,TP. Hồ Chí Minh, Việt Nam", "Trường Đại học Công nghệ Thành phố Hồ Chí Minh  ( Thủ đức Campus )" }
            //    });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "FileName", "LocationId", "LocationsDetailId", "Path" },
                values: new object[,]
                {
                    { 100, null, 100, null, "https://drive.google.com/uc?export=view&id=1fHOZklZjf9AatLGCPmQkV3YarE5s7Wjp" },
                    { 101, null, 101, null, "https://drive.google.com/uc?export=view&id=1K4ooUsEFygeX6QT0VEhg8rAJCRhZ9R52" },
                    { 102, null, 102, null, "https://drive.google.com/uc?export=view&id=1kWC4nZYnEzod1FCV6XRgvjiKsPMh0ExZ" },
                    { 103, null, 103, null, "https://drive.google.com/uc?export=view&id=18AGFSaOqlD9kCVdYJCGxW0uxLBlaOiiq" },
                    { 104, null, 104, null, "https://drive.google.com/uc?export=view&id=1Bnl07rzofdANpc2WpLHJuw3DCgNd9VSI" },
                    { 105, null, 105, null, "https://drive.google.com/uc?export=view&id=1waEm4TJvDVU4_3L_O5UK2f0RP5z5qQfi" },
                    { 106, null, 106, null, "https://drive.google.com/uc?export=view&id=1UNCVk-LPleq1c40b1ds9kRsKHzmHqfWw" },
                    { 107, null, 107, null, "https://drive.google.com/uc?export=view&id=1R9qLfvWn12fLQHYWtDbMegLo4HLsKPmX" },
                    { 108, null, 108, null, "https://drive.google.com/uc?export=view&id=1PzvX1Q5Y4huY_RnudtCazFUuSj9xuOlG" },
                    { 109, null, 109, null, "https://drive.google.com/uc?export=view&id=1AAO5vZrU53PDeypYUR3pV4u5UhkPd_O1" },
                    { 110, null, 110, null, "https://drive.google.com/uc?export=view&id=1PIK0JFgllAEa6RN4Opblx1K77UcelEZ5" },
                    { 111, null, 111, null, "https://drive.google.com/uc?export=view&id=1nSRZ9hTobuz-SHKd00KhDdV7XoluAYQK" },
                    { 112, null, 112, null, "https://drive.google.com/uc?export=view&id=1cjioOGuG1fr-4euclgnr0TnmmrU5TcZD" },
                    { 113, null, 113, null, "https://drive.google.com/uc?export=view&id=1C7zq3aLyTK4sGr6i7-TfSKkd-Aw1ptG-" },
                    { 114, null, 114, null, "https://drive.google.com/uc?export=view&id=1bMYjn3JpgI7YHEnQykuBAFfxC0Vazyqw" },
                    { 115, null, 115, null, "https://drive.google.com/uc?export=view&id=1f0i9wBq8A6DoFYAcX8hUbVe4Wf1yDQUq" },
                    { 116, null, 116, null, "https://drive.google.com/uc?export=view&id=1WdiUgauHIaDfwP_bDWU82Vqx-vmWXa9Z" },
                    { 117, null, 117, null, "https://drive.google.com/uc?export=view&id=19DacLfp54jpo1ewNoXGxpqny0SvxJnmz" },
                    { 118, null, 118, null, "https://drive.google.com/uc?export=view&id=1rii4B0soXl-fwucpEjAXmhyz7MMQ-myA" },
                    { 119, null, 119, null, "https://drive.google.com/uc?export=view&id=1tkwcEXYjTZn5SBXpBbdT4ikyIjICcqH3" },
                    { 120, null, 120, null, "https://drive.google.com/uc?export=view&id=1q9L3iReSw4sgz0QLHgQBHeZBGNt7iobb" },
                    { 121, null, 121, null, "https://drive.google.com/uc?export=view&id=1BYL9Hvry4zxawm2oxY8ssRXLW_GIWrbK" },
                    { 122, null, 122, null, "https://drive.google.com/uc?export=view&id=1nNybfHTFFpKy2lWp3ywijmEuoyPwYwt4" },
                    { 123, null, 123, null, "https://drive.google.com/uc?export=view&id=1qwwi96MqYdJC6DUAXrK9PQ_bn-eWCtZD" },
                    { 124, null, 124, null, "https://drive.google.com/uc?export=view&id=1eDbyrsZdqH5utcrG-sIOVF9j6TbS5W89" },
                    { 125, null, 125, null, "https://drive.google.com/uc?export=view&id=1TvfPRC_MzJA8EsOYRbP-bqKEzqxWpo3m" },
                    { 126, null, 126, null, "https://drive.google.com/uc?export=view&id=1vLrmVAm4u3VFhZ3e30num2FJ7IcpHPX4" },
                    { 127, null, 127, null, "https://drive.google.com/uc?export=view&id=1huB0477UFGuGlcqLRFkaS7v1Ea6JdWZW" },
                    { 128, null, 128, null, "https://drive.google.com/uc?export=view&id=1coJouzaEKjS9dGP2COMPazyG2G3mGxUD" },
                    { 129, null, 129, null, "https://drive.google.com/uc?export=view&id=1hkSbvZ6laBLO6jEaq9mQvL-weq1gX6l5" },
                    { 130, null, 130, null, "https://drive.google.com/uc?export=view&id=1xA1Uj-qEILAZ04UrdVotKkfyRPihrd3r" },
                    { 131, null, 131, null, "https://drive.google.com/uc?export=view&id=1xr3M5sb0tKp8MDse3US1NzxnjoKN9tty" },
                    { 132, null, 132, null, "https://drive.google.com/uc?export=view&id=1W5lZtJfhsnLAaA_o8x-qWEFG9zNTTxIZ" },
                    { 133, null, 133, null, "https://drive.google.com/uc?export=view&id=1JT_h0T3bmdjqRRZr1wQrnqCrKE2rB8yl" },
                    { 134, null, 134, null, "https://drive.google.com/uc?export=view&id=13rM4ccF2DXUHkv2obM0osGOs2Rvy6a8I" },
                    { 135, null, 135, null, "https://drive.google.com/uc?export=view&id=1TJjrOqRAhJ-8thxNO3YdcC4uHUtEi3-W" },
                    { 136, null, 136, null, "https://drive.google.com/uc?export=view&id=1bXK36UtHqWggEr1Yk9I7V11yeaUjvUdc" },
                    { 137, null, 137, null, "https://drive.google.com/uc?export=view&id=16yktL6QoBK0ec-PsnMK8u8sbMslLHrtg" },
                    { 138, null, 138, null, "https://drive.google.com/uc?export=view&id=10Mjl_UX6YYnxfM9LBaKWz10F5p3KnQ5k" },
                    { 139, null, 139, null, "https://drive.google.com/uc?export=view&id=1E3Nu7KhR-hZzi8d1geekxGHUXJUgCX0Z" },
                    { 140, null, 140, null, "https://drive.google.com/uc?export=view&id=1mNK-Bysxg90876o9cRMVE--xAzm5bS2E" },
                    { 141, null, 141, null, "https://drive.google.com/uc?export=view&id=18uda_mP0wTbHET2mWsds6aC3J-GVrCXh" },
                    { 142, null, 142, null, "https://drive.google.com/uc?export=view&id=11_L8m1S3XRfHSKC_5_MkiSc-EbMZ5AQN" },
                    { 143, null, 143, null, "https://drive.google.com/uc?export=view&id=1D42PxvUs1oWT8UVsikjscrt94B5i7vGk" },
                    { 144, null, 144, null, "https://drive.google.com/uc?export=view&id=1GUOlBXCGMI0OjF8qXmwlxxmizww8HzBB" },
                    { 145, null, 145, null, "https://drive.google.com/uc?export=view&id=10xyM2v1VrwfYhPN2z1b-P-aTqDNLtXFO" },
                    { 146, null, 146, null, "https://drive.google.com/uc?export=view&id=1zqKNc8iD_eBxkQMw-RpSlN5xRhT_L_48" },
                    { 147, null, 147, null, "https://drive.google.com/uc?export=view&id=1In_gKRvfxPL7HDSa7ajfnHqw-h41J5eu" },
                    { 148, null, 148, null, "https://drive.google.com/uc?export=view&id=1muXfZ1NI5802rhf5K56aNEFIe3VWhCmW" },
                    { 149, null, 149, null, "https://drive.google.com/uc?export=view&id=12lSjx2kAZ_4QKNkrF3WdLwdDWZcFCA7d" },
                    { 150, null, 150, null, "https://drive.google.com/uc?export=view&id=1YCpp-SLUCaF6bG_7ThevfQkEunkFi2Lg" },
                    { 151, null, 151, null, "https://drive.google.com/uc?export=view&id=1mCJDso1_7SUMzTqLWbb-LhDN_s8auY9R" },
                    { 152, null, 152, null, "https://drive.google.com/uc?export=view&id=1VbHR10OTxGiHPysB5cSzOsa2JrAhiX3C" },
                    { 153, null, 153, null, "https://drive.google.com/uc?export=view&id=1IDx-I98-YJrS4V1o31H1qGJxK0y-yznP" },
                    { 154, null, 154, null, "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu" },
                    { 155, null, 155, null, "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu" },
                    { 156, null, 156, null, "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu" },
                    { 157, null, 157, null, "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu" },
                    { 158, null, 158, null, "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu" },
                    { 159, null, 159, null, "https://drive.google.com/uc?export=view&id=1osjGuuBmGRN9hFBSZlDkeZ509cElGmzG" },
                    { 160, null, 160, null, "https://drive.google.com/uc?export=view&id=1pYNym5ylCPQrBH8S9YLDxA-Ll7izvOa0" },
                    { 161, null, 161, null, "https://drive.google.com/uc?export=view&id=1Po7TnNb9d4r9MpBZotFdfAI88D65gplv" },
                    { 162, null, 162, null, "https://drive.google.com/uc?export=view&id=1iP4s0LuF7ChPsrNSOnjF2ELqL_x_0vMu" },
                    { 163, null, 163, null, "https://drive.google.com/uc?export=view&id=1a8EjKeMsREiOZSMXiKi_8fVJAdvf-OR8" },
                    { 164, null, 164, null, "https://drive.google.com/uc?export=view&id=1kF3ovOwv7T27mj2QzvF83litiTt4iuy2" },
                    { 165, null, 165, null, "https://drive.google.com/uc?export=view&id=1XKDI9qr2CVKocZhhMJCAkbpARvFnrJVm" },
                    { 166, null, 166, null, "https://drive.google.com/uc?export=view&id=1w-2BZjO_whBby3mMrdCYfQG14PQJgrrT" },
                    { 167, null, 167, null, "https://drive.google.com/uc?export=view&id=12XYgeFHpABQSfHZ5sd7uN2ERHU066H_l" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 167);

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

            migrationBuilder.AlterColumn<int>(
                name: "LocationsDetailId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Images",
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
                value: "8c3c05ea-bba4-411c-ad3d-e8cf64c6caad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a"),
                column: "ConcurrencyStamp",
                value: "ed5a3644-b577-408b-b979-fe4c0e257d90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1f771da-b318-42f8-a003-5a15614216f5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29cb008e-a579-441b-a93b-684486a2165d", "AQAAAAEAACcQAAAAENY7LNKJ1PtLsTYAI1xRsuCx0rO7ty0H5mWWEAE6p44uUCneKxECncdGhTGxCrx6ZQ==" });
        }
    }
}
