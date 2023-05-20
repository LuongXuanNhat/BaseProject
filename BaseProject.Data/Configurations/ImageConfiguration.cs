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
            builder.Property(c => c.LocationsDetailId).IsRequired(false);
            builder.Property(c => c.LocationId).IsRequired(false);



            // Relationship
            builder.HasOne(x => x.LocationsDetail).WithMany(x => x.Image).HasForeignKey(x => x.LocationsDetailId);
            builder.HasOne(x => x.Location).WithMany(x => x.Image).HasForeignKey(x => x.LocationId);
        }

    }
}
