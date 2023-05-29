using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class CategoriesLocationConfiguration : IEntityTypeConfiguration<CategoriesLocation>
    {
        public void Configure(EntityTypeBuilder<CategoriesLocation> builder)
        {
            builder.ToTable("CategoriesLocations");
            
            builder.HasKey(x => new { x.CategoriesId, x.LocationId });
            builder.Property(x=>x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(250);


            // RelationShip 1 -n
            builder.HasOne(x => x.Category).WithMany(x => x.CategoriesLocation).HasForeignKey(x => x.CategoriesId);
            builder.HasOne(x => x.Location).WithMany(x => x.CategoriesLocation).HasForeignKey(x => x.LocationId);

        }
    }
}
