using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class RatingLocationConfiguration : IEntityTypeConfiguration<RatingLocation>
    {
        public void Configure(EntityTypeBuilder<RatingLocation> builder)
        {
            builder.ToTable("RatingLocations");


            builder.HasKey(x => x.Id);


            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.RatingLocation).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Location).WithMany(x => x.RatingLocation).HasForeignKey(x => x.LocationId);
        }

    }
}
