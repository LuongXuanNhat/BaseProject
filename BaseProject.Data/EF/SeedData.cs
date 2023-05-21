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
                    Name = "Quán Cà Phê Trung Nguyên  ",
                    Address = "19B Phạm Ngọc Thạch, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
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
                    Name = "Bãi biển Vũng Tàu ",
                    Address = "Thùy Vân, Thành phố Vũng Tàu , Việt Nam"
                },
                new Location()
                {LocationId = 104,
                    Name = "Khu bảo tồn Thiên nhiên Cần Giờ ",
                    Address = " Cần Giờ ,TP. Hồ Chí Minh, Việt Nam"
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
                {LocationId = 111,
                    Name = "Quán ăn Ngon Xưa ",
                    Address = "138 Nguyễn Thị Minh Khai, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 112,
                    Name = "Bảo tàng Mỹ thuật TP. Hồ Chí Minh  ",
                    Address = " 97A Phó Đức Chính, Nguyễn Thái Bình, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
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
                {LocationId = 116,
                    Name = "Nhà hàng Huế Cẩm ",
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
                    Name = "Khu du lịch Bình Quới ",
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
                    Address = "80 D2, Tổ 4, Phường 11, Quận Tân Bình ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 128,
                    Name = "Bảo tàng Lịch sử TP. Hồ Chí Minh ",
                    Address = "1 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 129,
                    Name = "Khu phố Tây Bùi Viện ",
                    Address = " Phạm Ngũ Lão, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 130,
                    Name = "Công viên Lê Văn Tám ",
                    Address = "Đồng Khởi, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 131,
                    Name = "Quán ăn Lẩu Bò Tòng Dương  ",
                    Address = " 110 Cống Quỳnh, Phường Phạm Ngũ Lão, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
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
                {LocationId = 134,
                    Name = "Nhà thờ Đức Bà Sài Gòn ",
                    Address = "01 Công xã Paris, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 135,
                    Name = "Nhà hàng Buffet Villa ",
                    Address = " 99 Nguyễn Huệ, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
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
                {LocationId = 140,
                    Name = "Nhà hàng Hủ Tiếu Mỹ Tho 3 Miền ",
                    Address = " 229 Đường 3/2, Phường 12, Quận 10 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 141,
                    Name = "Công viên Cá Mập ",
                    Address = "Đại lộ Nguyễn Văn Linh, Phường 7, Quận 7 ,TP. Hồ Chí Minh, Việt Nam"
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
                {LocationId = 144,
                    Name = "Khu vui chơi giải trí 7 viên ngọc rồng ",
                    Address = "202 Lê Hồng Phong, Phường 4, Quận 5 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 145,
                    Name = "Trường Đại học Kinh tế TP. Hồ Chí Minh ",
                    Address = "59C Nguyễn Đình Chiểu, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 146,
                    Name = "Rạp chiếu phim CGV Cinemas ",
                    Address = "ầng 5, Parkson Flemington, 184 Lê Đại Hành, Phường 15, Quận 11 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 147,
                    Name = "Công viên Văn hóa Đầm Sen ",
                    Address = "3 Hòa Bình, Phường 3, Quận 11 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 148,
                    Name = "Quán cà phê The Coffee Bean & Tea Leaf  ",
                    Address = "14 Nguyễn Thị Minh Khai, Bến Nghé, Quận 1 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 149,
                    Name = "Khu du lịch Đầm Sen ",
                    Address = " ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 150,
                    Name = "176 Đường Hồng Lạc, Phường 10, Quận 11 ",
                    Address = " ,TP. Hồ Chí Minh, Việt Nam"
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
                    Name = "Start Cup Coffee ",
                    Address = "80 Hoàng Hoa Thám, Phường 12, Tân Bình ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 155,
                    Name = "Start Cup Coffee ",
                    Address = " 82 Võ Văn Tần, Phường 6, Quận 3 ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 156,
                    Name = "Start Cup Coffee ",
                    Address = "63 Nguyễn Huệ, Bến Nghé, Quận 1  ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {LocationId = 157,
                    Name = "Start Cup Coffee ",
                    Address = " 190 Xô Viết Nghệ Tĩnh, Phường 21, Bình Thạnh ,TP. Hồ Chí Minh, Việt Nam"
                },
                new Location()
                {
                    LocationId = 158,
                    Name = "Start Cup Coffee ",
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

            //      Images Location
            //modelBuilder.Entity<Image>().HasData(
            //    new Image
            //    { 
            //        ImageId = 50,
            //        LocationId = 100,
            //        Path = ""
            //    },
            //    new Image
            //    {
            //        ImageId = 51,
            //        LocationId = 101,
            //        Path = ""
            //    },

            //    );

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
