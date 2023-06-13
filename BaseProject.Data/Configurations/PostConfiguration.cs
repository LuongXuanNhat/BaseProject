using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.PostId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.View).HasDefaultValue(0);
            builder.Property(x => x.Check).HasDefaultValue(YesNo.no);


            // Relationship 1-n

        }
    }
}
