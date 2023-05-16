using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(x => x.ImageId);
            builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);


            // Relationship
            builder.HasOne(x => x.LocationsDetail).WithMany(x => x.Image).HasForeignKey(x => x.LocationsDetailId);
            builder.HasOne(x => x.Location).WithMany(x => x.Image).HasForeignKey(x => x.LocationId);
        }

    }
}
