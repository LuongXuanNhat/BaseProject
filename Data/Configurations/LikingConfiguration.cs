﻿using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class LikingConfiguration : IEntityTypeConfiguration<Liking>
    {
        public void Configure(EntityTypeBuilder<Liking> builder)
        {
            builder.ToTable("Likings");

            builder.HasKey(x => x.Id);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Liking).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Liking).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Comment).WithMany(x => x.Liking).HasForeignKey(x => x.CommentId);
        }

    }
}
