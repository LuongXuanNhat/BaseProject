using BaseProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace BaseProject.Data.EF
{
    public class SeedData
    {
        private readonly ModelBuilder modelBuilder;

        public SeedData(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            //      AppConfig
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "Đây là trang chủ của Web_Review" },
               new AppConfig() { Key = "HomeKeyWord", Value = "Đây là từ khóa của Web_Review" },
               new AppConfig() { Key = "HomeDescription", Value = "Đây là mô tả của Web_Review" }
               );

            //      Category
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoriesId = 1,
                    Name = "Ẩm thực",
                },
                new Category()
                {
                    CategoriesId = 2,
                    Name = "Khám phá",
                },
                new Category()
                {
                    CategoriesId = 3,
                    Name = "Vui chơi-Giải trí",
                },
                new Category()
                {
                    CategoriesId = 4,
                    Name = "Nghỉ dưỡng",
                },
                new Category()
                {
                    CategoriesId = 5,
                    Name = "Bãi biển",
                },
                new Category()
                {
                    CategoriesId = 6,
                    Name = "Cắm trại",
                },
                new Category()
                {
                    CategoriesId = 7,
                    Name = "Khu di tích",
                },
                new Category()
                {
                    CategoriesId = 8,
                    Name = "Bảo tàng",
                },
                new Category()
                {
                    CategoriesId = 9,
                    Name = "Khu du lịch",
                },
                new Category()
                {
                    CategoriesId = 10,
                    Name = "Công viên",
                },
                new Category()
                {
                    CategoriesId = 11,
                    Name = "Nhà thờ",
                },
                new Category()
                {
                    CategoriesId = 12,
                    Name = "Chợ",
                },
                new Category()
                {
                    CategoriesId = 13,
                    Name = "Hòn-Đảo",
                },
                new Category()
                {
                    CategoriesId = 14,
                    Name = "Hang động",
                },
                new Category()
                {
                    CategoriesId = 15,
                    Name = "Làng quê",
                },
                new Category()
                {
                    CategoriesId = 16,
                    Name = "Đền",
                },
                new Category()
                {
                    CategoriesId = 17,
                    Name = "Chùa",
                },
                new Category()
                {
                    CategoriesId = 18,
                    Name = "Núi",
                },
                new Category()
                {
                    CategoriesId = 19,
                    Name = "Đặc sản",
                },
                new Category()
                {
                    CategoriesId = 20,
                    Name = "Thác",
                });

            //      Location
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    LocationId = 100,
                    Name = "Công viên 23/9",
                    Address = "Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 101,
                    Name = " Bảo tàng Hồ Chí Minh",
                    Address = "9 Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 102,
                    Name = " Nhà hàng Ngon",
                    Address = "160 Pasteur, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 103,
                    Name = "Bãi Thùy Vân (bãi Sau)",
                    Address = "Đường Thùy Vân, Tp. Vũng Tàu, Việt Nam"
                },
                new Location()
                {LocationId = 104,
                    Name = "Rừng Sác",
                    Address = "đường Rừng Sác, xã Long Hòa, huyện Cần Giờ, Thành phố Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 105,
                    Name = "Rạp chiếu phim CGV Crescent Mall ",
                    Address = "101 Tôn Dật Tiên, Tân Phú, Quận 7 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 106,
                    Name = "Trường Đại học Khoa học Xã hội và Nhân văn ",
                    Address = "10-12 Đinh Tiên Hoàng, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 107,
                    Name = "Công viên Tao Đàn ",
                    Address = "Trương Định, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 108,
                    Name = "Nhà thờ Đức Bà Sài Gòn ",
                    Address = "01 Công xã Paris, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 109,
                    Name = "Khu du lịch Suối Tiên ",
                    Address = "120 Xa lộ Hà Nội, Tân Phú, Quận 9 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 110,
                    Name = "Nhà hát Thành phố Hồ Chí Minh  ",
                    Address = "7 Công trường Lam Sơn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 111,
                    Name = "Nhà Thờ Cha Tam",
                    Address = "số 25 đường Học Lạc, phường 14, quận 5, thành phố Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 112,
                    Name = "Công Viên Cá Koi Rinrin Park",
                    Address = "87/8P Xuân Thới Thượng 6, xã Xuân Thới Đông, huyện Hóc Môn, thành phố Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 113,
                    Name = " Trường Quốc tế Úc ",
                    Address = "216 Võ Thị Sáu, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 114,
                    Name = "Nhà thờ Tân Định ",
                    Address = "289 Hai Bà Trưng, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 115,
                    Name = "Khu công viên 30/4  ",
                    Address = "108-120 Lê Duẩn, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 116,
                    Name = "Công Viên Nước Lego Water Park",
                    Address = "233B Nguyễn Văn Cừ, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 117,
                    Name = "Chùa Giác Lâm ",
                    Address = "565 Lạc Long Quân, Phường 10, Quận Tân Bình ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 118,
                    Name = "Khu du lịch Văn Thánh ",
                    Address = "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 119,
                    Name = "Nhà hàng Làng Nướng Nam Bộ  ",
                    Address = " 728 Võ Văn Kiệt, Phường 1, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 120,
                    Name = "Khu du lịch Bình Quới 1",
                    Address = "1147 Bình Quới, Phường 28, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 121,
                    Name = "Rạp chiếu phim CGV Liberty Citypoint ",
                    Address = " 59-61 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 122,
                    Name = "Chợ Bến Thành ",
                    Address = "Lê Lợi, Phường Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 123,
                    Name = "Quán ăn Huỳnh Hoa",
                    Address = "26 Lê Thị Riêng, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 124,
                    Name = "Công viên Gia Định ",
                    Address = "Phạm Văn Đồng, Phường 3, Quận Gò Vấp ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 125,
                    Name = "Nhà hát Kịch TP. Hồ Chí Minh  ",
                    Address = "30 Trần Hưng Đạo, Cầu Ông Lãnh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 126,
                    Name = "Quán cà phê Cộng Cà Phê ",
                    Address = " 14E1 Nguyễn Thị Minh Khai, Đa Kao, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 127,
                    Name = "Trung tâm Thể thao Rạch Miễu ",
                    Address = "Số 01 đường Hoa Phượng, phường 2, quận Phú Nhuận ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 128,
                    Name = "Bảo tàng Lịch sử TP. Hồ Chí Minh ",
                    Address = "1 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 129,
                    Name = "Phố đi bộ Bùi Viện ",
                    Address = " Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 130,
                    Name = "Công viên Lê Văn Tám ",
                    Address = "Đồng Khởi, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 131,
                    Name = "Cầu Mống",
                    Address = "22A Bến Vân Đồn, Phường 12, Quận 4, Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 132,
                    Name = "Khu du lịch Vạn Hạnh Mall ",
                    Address = "11 Sư Vạn Hạnh, Phường 12, Quận 10 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 133,
                    Name = "Trung tâm mua sắm Vincom Center Landmark 81 ",
                    Address = "720A Điện Biên Phủ, Phường 22, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 134,
                    Name = "Địa Đạo Củ Chi",
                    Address = "Ấp Phú Hiệp, xã Phú Mỹ Hưng, huyện Củ Chi, Tp. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 135,
                    Name = "Hồ Con Rùa",
                    Address = "Nằm giữa 3 đường: Võ Văn Tần, Phạm Ngọc Thạch và Trần Cao Vân, quận 3, TP Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 136,
                    Name = "Khu du lịch Bửu Long ",
                    Address = "905A Hùng Vương, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 137,
                    Name = "Bảo tàng Mỹ thuật TP. Hồ Chí Minh ",
                    Address = "97A Phó Đức Chính, Nguyễn Thái Bình, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 138,
                    Name = "Công viên Lê Thị Riêng ",
                    Address = "23-25 Lê Thị Riêng, Bến Thành, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 139,
                    Name = "Trường Đại học Bách Khoa TP. Hồ Chí Minh ",
                    Address = "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 140,
                    Name = "Khu Du Lịch Suối Mơ",
                    Address = "Đường 11,phường Long Thạnh Mỹ, Quận 9, Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 141,
                    Name = "Tòa Tháp Bitexco",
                    Address = "7, 2 Hải Triều, Bến Nghé, Quận 1, Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 142,
                    Name = "Khu du lịch Văn Thánh Miếu Nổi  ",
                    Address = "48 Văn Thánh, Phường 9, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 143,
                    Name = "Quán cà phê The Coffee House ",
                    Address = "15 Nguyễn Thị Minh Khai, Phường Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 144,
                    Name = "Công Viên Nước Đại Thế Giới",
                    Address = "106 Võ Văn Kiệt, Phường 6, Quận 5, TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 145,
                    Name = "Trường Đại học Kinh tế TP. Hồ Chí Minh ",
                    Address = "59C Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 146,
                    Name = "Rạp chiếu phim CGV Cinemas ",
                    Address = "Tầng 5, Parkson Flemington, 184 Lê Đại Hành, Phường 15, Quận 11 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 147,
                    Name = "Công viên Văn hóa Đầm Sen ",
                    Address = "3 Hòa Bình, Phường 3, Quận 11 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 148,
                    Name = "Quán cà phê The Coffee Bean & Tea Leaf",
                    Address = "14 Nguyễn Thị Minh Khai, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 149,
                    Name = "Bảo Tàng Tranh 3D Sài Gòn",
                    Address = "Đường số 9, Khu đô thị Him Lam, Quận 7, Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 150,
                    Name = "Khu Đô Thị Phú Mỹ Hưng",
                    Address = "Tân Phong, Quận 7, thành phố Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 151,
                    Name = "Quán cà phê Highlands Coffee  ",
                    Address = "157-159 Nguyễn Thị Minh Khai, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 152,
                    Name = "Quán ăn Bánh Cuốn Tây Hồ  ",
                    Address = " 127 Trần Quốc Thảo, Phường 7, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 153,
                    Name = "Quán cà phê Trung Nguyên Legend Café ",
                    Address = "264A Nam Kỳ Khởi Nghĩa, Phường 8, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 154,
                    Name = "Star Cup Coffee ",
                    Address = "80 Hoàng Hoa Thám, Phường 12, Tân Bình ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 155,
                    Name = "Star Cup Coffee ",
                    Address = " 82 Võ Văn Tần, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 156,
                    Name = "Star Cup Coffee ",
                    Address = "63 Nguyễn Huệ, Bến Nghé, Quận 1  ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 157,
                    Name = "Star Cup Coffee ",
                    Address = " 190 Xô Viết Nghệ Tĩnh, Phường 21, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 158,
                    Name = "Star Cup Coffee ",
                    Address = " 297 Nguyễn Trãi, Phường Nguyễn Cư Trinh, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 159,
                    Name = "Đại học Sư phạm TP. Hồ Chí Minh ",
                    Address = "280 An Dương Vương, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 160,
                    Name = "Đại học Ngoại thương TP. Hồ Chí Minh ",
                    Address = "2 Trường Sa, Phường 17, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 161,
                    Name = "Đại học Y Dược TP. Hồ Chí Minh ",
                    Address = " 217 Hồng Bàng, Phường 11, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 162,
                    Name = "Đại học Công nghệ Thông tin TP. Hồ Chí Minh ",
                    Address = "268 Lý Thường Kiệt, Phường 14, Quận 10 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 163,
                    Name = "Đại học Sài Gòn  ",
                    Address = " 273 An Dương Vương, Phường 3, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 164,
                    Name = "Đại học Văn Hiến  ",
                    Address = "202 Lê Văn Sỹ, Phường 10, Quận Phú Nhuận ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 165,
                    Name = "Trường Đại học Công nghệ Thành phố Hồ Chí Minh (Cơ sở chính - SaiGon Campus) ",
                    Address = "475A Điện Biên Phủ, Phường 25, Quận Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 166,
                    Name = "Trường Đại học Công nghệ Thành phố Hồ Chí Minh ( Cơ sở Ung Văn Khiêm)",
                    Address = " 2, đường Ung Văn Khiêm, Phường 25, Quận Bình Thạnh  ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 167,
                    Name = "Trường Đại học Công nghệ Thành phố Hồ Chí Minh  ( Thủ đức Campus )",
                    Address = "10/80C XL Hà Nội, Phường Tân Phú, Thủ Đức ,TP. Hồ Chí Minh, Việt Nam"
                }

                );

            //images location
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ImageId = 100,
                    LocationId = 100,
                    Path = "https://drive.google.com/uc?export=view&id=1fHOZklZjf9AatLGCPmQkV3YarE5s7Wjp"
                },
                new Image
                {
                    ImageId = 101,
                    LocationId = 101,
                    Path = "https://drive.google.com/uc?export=view&id=1K4ooUsEFygeX6QT0VEhg8rAJCRhZ9R52"
                },
                new Image
                {
                    ImageId = 102,
                    LocationId = 102,
                    Path = "https://drive.google.com/uc?export=view&id=1kWC4nZYnEzod1FCV6XRgvjiKsPMh0ExZ"
                }, new Image
                {
                    ImageId = 103,
                    LocationId = 103,
                    Path = "https://drive.google.com/uc?export=view&id=18AGFSaOqlD9kCVdYJCGxW0uxLBlaOiiq"
                },
                new Image
                {
                    ImageId = 104,
                    LocationId = 104,
                    Path = "https://drive.google.com/uc?export=view&id=1Bnl07rzofdANpc2WpLHJuw3DCgNd9VSI"
                },
                new Image
                {
                    ImageId = 105,
                    LocationId = 105,
                    Path = "https://drive.google.com/uc?export=view&id=1waEm4TJvDVU4_3L_O5UK2f0RP5z5qQfi"
                },
                new Image
                {
                    ImageId = 106,
                    LocationId = 106,
                    Path = "https://drive.google.com/uc?export=view&id=1UNCVk-LPleq1c40b1ds9kRsKHzmHqfWw"
                }, new Image
                {
                    ImageId = 107,
                    LocationId = 107,
                    Path = "https://drive.google.com/uc?export=view&id=1R9qLfvWn12fLQHYWtDbMegLo4HLsKPmX"
                },
                new Image
                {
                    ImageId = 108,
                    LocationId = 108,
                    Path = "https://drive.google.com/uc?export=view&id=1PzvX1Q5Y4huY_RnudtCazFUuSj9xuOlG"
                },
                new Image
                {
                    ImageId = 109,
                    LocationId = 109,
                    Path = "https://drive.google.com/uc?export=view&id=1AAO5vZrU53PDeypYUR3pV4u5UhkPd_O1"
                }, new Image
                {
                    ImageId = 110,
                    LocationId = 110,
                    Path = "https://drive.google.com/uc?export=view&id=1PIK0JFgllAEa6RN4Opblx1K77UcelEZ5"
                },
                new Image
                {
                    ImageId = 111,
                    LocationId = 111,
                    Path = "https://drive.google.com/uc?export=view&id=1nSRZ9hTobuz-SHKd00KhDdV7XoluAYQK"
                },
                new Image
                {
                    ImageId = 112,
                    LocationId = 112,
                    Path = "https://drive.google.com/uc?export=view&id=1cjioOGuG1fr-4euclgnr0TnmmrU5TcZD"
                },
                new Image
                {
                    ImageId = 113,
                    LocationId = 113,
                    Path = "https://drive.google.com/uc?export=view&id=1C7zq3aLyTK4sGr6i7-TfSKkd-Aw1ptG-"
                },
                new Image
                {
                    ImageId = 114,
                    LocationId = 114,
                    Path = "https://drive.google.com/uc?export=view&id=1bMYjn3JpgI7YHEnQykuBAFfxC0Vazyqw"
                },
                new Image
                {
                    ImageId = 115,
                    LocationId = 115,
                    Path = "https://drive.google.com/uc?export=view&id=1f0i9wBq8A6DoFYAcX8hUbVe4Wf1yDQUq"
                },
                new Image
                {
                    ImageId = 116,
                    LocationId = 116,
                    Path = "https://drive.google.com/uc?export=view&id=1WdiUgauHIaDfwP_bDWU82Vqx-vmWXa9Z"
                },
                new Image
                {
                    ImageId = 117,
                    LocationId = 117,
                    Path = "https://drive.google.com/uc?export=view&id=19DacLfp54jpo1ewNoXGxpqny0SvxJnmz"
                },
                new Image
                {
                    ImageId = 118,
                    LocationId = 118,
                    Path = "https://drive.google.com/uc?export=view&id=1rii4B0soXl-fwucpEjAXmhyz7MMQ-myA"
                },
                new Image
                {
                    ImageId = 119,
                    LocationId = 119,
                    Path = "https://drive.google.com/uc?export=view&id=1tkwcEXYjTZn5SBXpBbdT4ikyIjICcqH3"
                },
                new Image
                {
                    ImageId = 120,
                    LocationId = 120,
                    Path = "https://drive.google.com/uc?export=view&id=1q9L3iReSw4sgz0QLHgQBHeZBGNt7iobb"
                },
                new Image
                {
                    ImageId = 121,
                    LocationId = 121,
                    Path = "https://drive.google.com/uc?export=view&id=1BYL9Hvry4zxawm2oxY8ssRXLW_GIWrbK"
                },
                new Image
                {
                    ImageId = 122,
                    LocationId = 122,
                    Path = "https://drive.google.com/uc?export=view&id=1nNybfHTFFpKy2lWp3ywijmEuoyPwYwt4"
                },
                new Image
                {
                    ImageId = 123,
                    LocationId = 123,
                    Path = "https://drive.google.com/uc?export=view&id=1qwwi96MqYdJC6DUAXrK9PQ_bn-eWCtZD"
                },
                new Image
                {
                    ImageId = 124,
                    LocationId = 124,
                    Path = "https://drive.google.com/uc?export=view&id=1eDbyrsZdqH5utcrG-sIOVF9j6TbS5W89"
                },
                new Image
                {
                    ImageId = 125,
                    LocationId = 125,
                    Path = "https://drive.google.com/uc?export=view&id=1TvfPRC_MzJA8EsOYRbP-bqKEzqxWpo3m"
                },
                new Image
                {
                    ImageId = 126,
                    LocationId = 126,
                    Path = "https://drive.google.com/uc?export=view&id=1vLrmVAm4u3VFhZ3e30num2FJ7IcpHPX4"
                },
                new Image
                {
                    ImageId = 127,
                    LocationId = 127,
                    Path = "https://drive.google.com/uc?export=view&id=1huB0477UFGuGlcqLRFkaS7v1Ea6JdWZW"
                },
                new Image
                {
                    ImageId = 128,
                    LocationId = 128,
                    Path = "https://drive.google.com/uc?export=view&id=1coJouzaEKjS9dGP2COMPazyG2G3mGxUD"
                },
                new Image
                {
                    ImageId = 129,
                    LocationId = 129,
                    Path = "https://drive.google.com/uc?export=view&id=1hkSbvZ6laBLO6jEaq9mQvL-weq1gX6l5"
                },
                new Image
                {
                    ImageId = 130,
                    LocationId = 130,
                    Path = "https://drive.google.com/uc?export=view&id=1xA1Uj-qEILAZ04UrdVotKkfyRPihrd3r"
                },
                new Image
                {
                    ImageId = 131,
                    LocationId = 131,
                    Path = "https://drive.google.com/uc?export=view&id=1xr3M5sb0tKp8MDse3US1NzxnjoKN9tty"
                },
                new Image
                {
                    ImageId = 132,
                    LocationId = 132,
                    Path = "https://drive.google.com/uc?export=view&id=1W5lZtJfhsnLAaA_o8x-qWEFG9zNTTxIZ"
                },
                new Image
                {
                    ImageId = 133,
                    LocationId = 133,
                    Path = "https://drive.google.com/uc?export=view&id=1JT_h0T3bmdjqRRZr1wQrnqCrKE2rB8yl"
                },
                new Image
                {
                    ImageId = 134,
                    LocationId = 134,
                    Path = "https://drive.google.com/uc?export=view&id=13rM4ccF2DXUHkv2obM0osGOs2Rvy6a8I"
                },
                new Image
                {
                    ImageId = 135,
                    LocationId = 135,
                    Path = "https://drive.google.com/uc?export=view&id=1TJjrOqRAhJ-8thxNO3YdcC4uHUtEi3-W"
                },
                new Image
                {
                    ImageId = 136,
                    LocationId = 136,
                    Path = "https://drive.google.com/uc?export=view&id=1bXK36UtHqWggEr1Yk9I7V11yeaUjvUdc"
                },
                new Image
                {
                    ImageId = 137,
                    LocationId = 137,
                    Path = "https://drive.google.com/uc?export=view&id=16yktL6QoBK0ec-PsnMK8u8sbMslLHrtg"
                },
                new Image
                {
                    ImageId = 138,
                    LocationId = 138,
                    Path = "https://drive.google.com/uc?export=view&id=10Mjl_UX6YYnxfM9LBaKWz10F5p3KnQ5k"
                },
                new Image
                {
                    ImageId = 139,
                    LocationId = 139,
                    Path = "https://drive.google.com/uc?export=view&id=1E3Nu7KhR-hZzi8d1geekxGHUXJUgCX0Z"
                },
                new Image
                {
                    ImageId = 140,
                    LocationId = 140,
                    Path = "https://drive.google.com/uc?export=view&id=1mNK-Bysxg90876o9cRMVE--xAzm5bS2E"
                }, 
                new Image
                {
                    ImageId = 141,
                    LocationId = 141,
                    Path = "https://drive.google.com/uc?export=view&id=18uda_mP0wTbHET2mWsds6aC3J-GVrCXh"
                },
                new Image
                {
                    ImageId = 142,
                    LocationId = 142,
                    Path = "https://drive.google.com/uc?export=view&id=11_L8m1S3XRfHSKC_5_MkiSc-EbMZ5AQN"
                }, 
                new Image
                {
                    ImageId = 143,
                    LocationId = 143,
                    Path = "https://drive.google.com/uc?export=view&id=1D42PxvUs1oWT8UVsikjscrt94B5i7vGk"
                },
                new Image
                {
                    ImageId = 144,
                    LocationId = 144,
                    Path = "https://drive.google.com/uc?export=view&id=1GUOlBXCGMI0OjF8qXmwlxxmizww8HzBB"
                }, 
                new Image
                {
                    ImageId = 145,
                    LocationId = 145,
                    Path = "https://drive.google.com/uc?export=view&id=10xyM2v1VrwfYhPN2z1b-P-aTqDNLtXFO"
                },
                new Image
                {
                    ImageId = 146,
                    LocationId = 146,
                    Path = "https://drive.google.com/uc?export=view&id=1zqKNc8iD_eBxkQMw-RpSlN5xRhT_L_48"
                }, 
                new Image
                {
                    ImageId = 147,
                    LocationId = 147,
                    Path = "https://drive.google.com/uc?export=view&id=1In_gKRvfxPL7HDSa7ajfnHqw-h41J5eu"
                },
                new Image
                {
                    ImageId = 148,
                    LocationId = 148,
                    Path = "https://drive.google.com/uc?export=view&id=1muXfZ1NI5802rhf5K56aNEFIe3VWhCmW"
                }, 
                new Image
                {
                    ImageId = 149,
                    LocationId = 149,
                    Path = "https://drive.google.com/uc?export=view&id=12lSjx2kAZ_4QKNkrF3WdLwdDWZcFCA7d"
                },
                new Image
                {
                    ImageId = 150,
                    LocationId = 150,
                    Path = "https://drive.google.com/uc?export=view&id=1YCpp-SLUCaF6bG_7ThevfQkEunkFi2Lg"
                }, 
                new Image
                {
                    ImageId = 151,
                    LocationId = 151,
                    Path = "https://drive.google.com/uc?export=view&id=1mCJDso1_7SUMzTqLWbb-LhDN_s8auY9R"
                },
                new Image
                {
                    ImageId = 152,
                    LocationId = 152,
                    Path = "https://drive.google.com/uc?export=view&id=1VbHR10OTxGiHPysB5cSzOsa2JrAhiX3C"
                }, 
                new Image
                {
                    ImageId = 153,
                    LocationId = 153,
                    Path = "https://drive.google.com/uc?export=view&id=1IDx-I98-YJrS4V1o31H1qGJxK0y-yznP"
                },
                new Image
                {
                    ImageId = 154,
                    LocationId = 154,
                    Path = "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu"
                }, 
                new Image
                {
                    ImageId = 155,
                    LocationId = 155,
                    Path = "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu"
                },
                new Image
                {
                    ImageId = 156,
                    LocationId = 156,
                    Path = "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu"
                }, new Image
                {
                    ImageId = 157,
                    LocationId = 157,
                    Path = "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu"
                },
                new Image
                {
                    ImageId = 158,
                    LocationId = 158,
                    Path = "https://drive.google.com/uc?export=view&id=1VvzQnuphX8yr5qg5Jbq2yX0KjpwSSLqu"
                }, 
                new Image
                {
                    ImageId = 159,
                    LocationId = 159,
                    Path = "https://drive.google.com/uc?export=view&id=1osjGuuBmGRN9hFBSZlDkeZ509cElGmzG"
                },
                new Image
                {
                    ImageId = 160,
                    LocationId = 160,
                    Path = "https://drive.google.com/uc?export=view&id=1pYNym5ylCPQrBH8S9YLDxA-Ll7izvOa0"
                }, new Image
                {
                    ImageId = 161,
                    LocationId = 161,
                    Path = "https://drive.google.com/uc?export=view&id=1Po7TnNb9d4r9MpBZotFdfAI88D65gplv"
                },
                new Image
                {
                    ImageId = 162,
                    LocationId = 162,
                    Path = "https://drive.google.com/uc?export=view&id=1iP4s0LuF7ChPsrNSOnjF2ELqL_x_0vMu"
                }, 
                new Image
                {
                    ImageId = 163,
                    LocationId = 163,
                    Path = "https://drive.google.com/uc?export=view&id=1a8EjKeMsREiOZSMXiKi_8fVJAdvf-OR8"
                },
                new Image
                {
                    ImageId = 164,
                    LocationId = 164,
                    Path = "https://drive.google.com/uc?export=view&id=1kF3ovOwv7T27mj2QzvF83litiTt4iuy2"
                }, 
                new Image
                {
                    ImageId = 165,
                    LocationId = 165,
                    Path = "https://drive.google.com/uc?export=view&id=1XKDI9qr2CVKocZhhMJCAkbpARvFnrJVm"
                },
                new Image
                {
                    ImageId = 166,
                    LocationId = 166,
                    Path = "https://drive.google.com/uc?export=view&id=1w-2BZjO_whBby3mMrdCYfQG14PQJgrrT"
                }, 
                new Image
                {
                    ImageId = 167,
                    LocationId = 167,
                    Path = "https://drive.google.com/uc?export=view&id=12XYgeFHpABQSfHZ5sd7uN2ERHU066H_l"
                }
                );

            //      Category
            modelBuilder.Entity<CategoriesLocation>().HasData(
                new CategoriesLocation()
                {
                    Id = 1,
                    LocationId = 24,
                    CategoriesId = 18
                },
                new CategoriesLocation()
                {
                    Id = 2,
                    LocationId = 24,
                    CategoriesId = 15
                },
                new CategoriesLocation()
                {
                    Id = 3,
                    LocationId = 100,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 4,
                    LocationId = 100,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 5,
                    LocationId = 101,
                    CategoriesId = 8
                },
                new CategoriesLocation()
                {
                    Id = 6,
                    LocationId = 102,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 7,
                    LocationId = 102,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 8,
                    LocationId = 103,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 9,
                    LocationId = 103,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 10,
                    LocationId = 103,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 11,
                    LocationId = 103,
                    CategoriesId = 5
                },
                new CategoriesLocation()
                {
                    Id = 12,
                    LocationId = 103,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 13,
                    LocationId = 104,
                    CategoriesId = 18
                },
                new CategoriesLocation()
                {
                    Id = 14,
                    LocationId = 104,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 15,
                    LocationId = 104,
                    CategoriesId = 14
                },
                new CategoriesLocation()
                {
                    Id = 15,
                    LocationId = 105,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 16,
                    LocationId = 107,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 17,
                    LocationId = 108,
                    CategoriesId = 11
                },
                new CategoriesLocation()
                {
                    Id = 18,
                    LocationId = 109,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 19,
                    LocationId = 109,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 20,
                    LocationId = 109,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 21,
                    LocationId = 110,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 22,
                    LocationId = 110,
                    CategoriesId = 4
                },
                new CategoriesLocation()
                {
                    Id = 23,
                    LocationId = 111,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 24,
                    LocationId = 111,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 25,
                    LocationId = 112,
                    CategoriesId = 8
                },
                new CategoriesLocation()
                {
                    Id = 26,
                    LocationId = 114,
                    CategoriesId = 11
                },
                new CategoriesLocation()
                {
                    Id = 27,
                    LocationId = 115,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 28,
                    LocationId = 116,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 29,
                    LocationId = 116,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 30,
                    LocationId = 117,
                    CategoriesId = 17
                },
                new CategoriesLocation()
                {
                    Id = 31,
                    LocationId = 118,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 32,
                    LocationId = 118,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 33,
                    LocationId = 118,
                    CategoriesId = 16
                },
                new CategoriesLocation()
                {
                    Id = 34,
                    LocationId = 119,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 35,
                    LocationId = 120,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 36,
                    LocationId = 120,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 37,
                    LocationId = 120,
                    CategoriesId = 4
                },
                new CategoriesLocation()
                {
                    Id = 38,
                    LocationId = 121,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 39,
                    LocationId = 122,
                    CategoriesId = 12
                },
                new CategoriesLocation()
                {
                    Id = 40,
                    LocationId = 123,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 41,
                    LocationId = 123,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 42,
                    LocationId = 124,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 43,
                    LocationId = 125,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 44,
                    LocationId = 125,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 45,
                    LocationId = 126,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 46,
                    LocationId = 126,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 47,
                    LocationId = 126,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 48,
                    LocationId = 127,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 49,
                    LocationId = 128,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 50,
                    LocationId = 128,
                    CategoriesId = 8
                },
                new CategoriesLocation()
                {
                    Id = 51,
                    LocationId = 129,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 52,
                    LocationId = 129,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 53,
                    LocationId = 129,
                    CategoriesId = 4
                },
                new CategoriesLocation()
                {
                    Id = 54,
                    LocationId = 130,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 55,
                    LocationId = 130,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 56,
                    LocationId = 131,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 57,
                    LocationId = 131,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 58,
                    LocationId = 132,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 59,
                    LocationId = 132,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 60,
                    LocationId = 132,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 61,
                    LocationId = 132,
                    CategoriesId = 12
                },
                new CategoriesLocation()
                {
                    Id = 62,
                    LocationId = 132,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 63,
                    LocationId = 133,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 64,
                    LocationId = 133,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 65,
                    LocationId = 133,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 66,
                    LocationId = 133,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 67,
                    LocationId = 133,
                    CategoriesId = 12
                },
                new CategoriesLocation()
                {
                    Id = 68,
                    LocationId = 134,
                    CategoriesId = 11
                },
                new CategoriesLocation()
                {
                    Id = 69,
                    LocationId = 135,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 70,
                    LocationId = 135,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 71,
                    LocationId = 136,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 72,
                    LocationId = 136,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 73,
                    LocationId = 136,
                    CategoriesId = 4
                },
                new CategoriesLocation()
                {
                    Id = 74,
                    LocationId = 136,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 75,
                    LocationId = 137,
                    CategoriesId = 8
                },
                new CategoriesLocation()
                {
                    Id = 76,
                    LocationId = 137,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 77,
                    LocationId = 138,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 78,
                    LocationId = 138,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 79,
                    LocationId = 140,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 80,
                    LocationId = 141,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 81,
                    LocationId = 141,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 82,
                    LocationId = 142,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 83,
                    LocationId = 142,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 84,
                    LocationId = 142,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 85,
                    LocationId = 142,
                    CategoriesId = 4
                },
                new CategoriesLocation()
                {
                    Id = 86,
                    LocationId = 142,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 87,
                    LocationId = 143,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 88,
                    LocationId = 143,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 89,
                    LocationId = 144,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 90,
                    LocationId = 144,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 91,
                    LocationId = 146,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 92,
                    LocationId = 147,
                    CategoriesId = 10
                },
                new CategoriesLocation()
                {
                    Id = 93,
                    LocationId = 147,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 94,
                    LocationId = 147,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 95,
                    LocationId = 148,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 96,
                    LocationId = 148,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 97,
                    LocationId = 148,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 98,
                    LocationId = 149,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 99,
                    LocationId = 149,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 100,
                    LocationId = 149,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 101,
                    LocationId = 142,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 102,
                    LocationId = 136,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 103,
                    LocationId = 132,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 104,
                    LocationId = 120,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 105,
                    LocationId = 118,
                    CategoriesId = 9
                },
                new CategoriesLocation()
                {
                    Id = 106,
                    LocationId = 150,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 107,
                    LocationId = 151,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 108,
                    LocationId = 151,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 109,
                    LocationId = 152,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 110,
                    LocationId = 152,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 111,
                    LocationId = 152,
                    CategoriesId = 19
                },
                new CategoriesLocation()
                {
                    Id = 112,
                    LocationId = 153,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 113,
                    LocationId = 153,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 114,
                    LocationId = 153,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 115,
                    LocationId = 151,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 116,
                    LocationId = 154,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 117,
                    LocationId = 154,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 118,
                    LocationId = 155,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 119,
                    LocationId = 155,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 120,
                    LocationId = 156,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 121,
                    LocationId = 156,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 122,
                    LocationId = 157,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 123,
                    LocationId = 157,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 124,
                    LocationId = 158,
                    CategoriesId = 1
                },
                new CategoriesLocation()
                {
                    Id = 125,
                    LocationId = 158,
                    CategoriesId = 3
                },
                new CategoriesLocation()
                {
                    Id = 126,
                    LocationId = 168,
                    CategoriesId = 2
                },
                new CategoriesLocation()
                {
                    Id = 127,
                    LocationId = 168,
                    CategoriesId = 3
                }

            );

            //Data Seeding for Notification
            modelBuilder.Entity<Notification>().HasData(
                new Notification
                {
                   NotificationId = 1,
                   Title = "Thông báo hệ thống",
                   Date = new DateTime(2023, 6, 12, 3, 4, 44, 986, DateTimeKind.Local).AddTicks(7867)
                },
                new Notification
                {
                   NotificationId = 2,
                   Title = "Thông báo tương tác",
                   Date = new DateTime(2023, 6, 12, 3, 4, 44, 986, DateTimeKind.Local).AddTicks(7879)
                }

            );





            //      ADMINISTRATOR
            var roleId = new Guid("a18be9c0-aa65-4af8-bd17-00bd9344e575");
            var roleId1 = new Guid("cfafcfcd-d796-43f4-8ac0-ead43bd2f18a");
            var adminId = new Guid("D1F771DA-B318-42F8-A003-5A15614216F5");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator Role"
                },
                new AppRole
                {
                    Id = roleId1,
                    Name = "user",
                    NormalizedName = "user",
                    Description = "User Role"
                }) ;
                

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                Name = "Lương Xuân Nhất",
                Gender = Enums.Gender.Nam,
                NormalizedUserName = "admin",
                Email = "onionwebdev@gmail.com",
                NormalizedEmail = "onionwebdev@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null,"Aa@123"),
                SecurityStamp = string.Empty,
                Image = "",
                DateOfBir = new DateTime(2002, 03, 18),
                Address = "3a, Thạch Mỹ Lợi, Quận 2, Tp. Hồ Chí Minh"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });          
        }
    }
}
