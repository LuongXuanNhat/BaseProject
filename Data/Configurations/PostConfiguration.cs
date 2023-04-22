using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Post_id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.View).IsRequired(false);


            // Relationship 1-n

        }
    }
}
