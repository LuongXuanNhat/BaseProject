﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BaseProject.Data.Entities;
using BaseProject.Data.Enums;

namespace BaseProject.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired(false);
            builder.Property(x => x.Gender).HasDefaultValue(Gender.Không);
            builder.Property(x => x.Check).HasDefaultValue(YesNo.no);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(500);


        }
    }
}
