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
