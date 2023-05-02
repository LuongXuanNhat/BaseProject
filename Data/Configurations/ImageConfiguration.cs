﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(x => x.Image_id);
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);


            // Relationship
            builder.HasOne(x => x.Post).WithMany(x => x.Image).HasForeignKey(x => x.Post_id);
        }

    }
}
