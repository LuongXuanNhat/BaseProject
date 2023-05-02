using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Videos");

            builder.HasKey(x => x.VideoId);
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);


            // Relationship
            builder.HasOne(x => x.Post).WithMany(x => x.Video).HasForeignKey(x => x.PostId);
        }

    }
}
