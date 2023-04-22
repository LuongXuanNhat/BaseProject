using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class LocationsDetailConfiguration : IEntityTypeConfiguration<LocationsDetail>
    {
        public void Configure(EntityTypeBuilder<LocationsDetail> builder)
        {
            builder.ToTable("LocationsDetails");

            builder.HasKey(x => new { x.Location_id , x.Post_id });
            builder.Property(x => x.Title).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);
        }
    }
}
