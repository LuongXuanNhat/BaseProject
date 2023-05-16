using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class LocationsDetailConfiguration : IEntityTypeConfiguration<LocationsDetail>
    {
        public void Configure(EntityTypeBuilder<LocationsDetail> builder)
        {
            builder.ToTable("LocationsDetails");
            builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(1,1);
            builder.HasKey(x =>x.Id);
            builder.Property(x => x.Title).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);


            // RelationShip 1 -n
            builder.HasOne(x => x.Location).WithMany(x => x.LocationsDetail).HasForeignKey(x => x.LocationId);
            builder.HasOne(x => x.Post).WithMany(x => x.LocationsDetail).HasForeignKey(x => x.PostId);

        }
    }
}
