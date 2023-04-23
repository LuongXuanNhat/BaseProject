using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CategoriesDetailConfiguration : IEntityTypeConfiguration<CategoriesDetail>
    {
        public void Configure(EntityTypeBuilder<CategoriesDetail> builder)
        {
            builder.ToTable("CategoriesDetails");

            builder.HasKey(x => new {x.Categories_id, x.Post_id});
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(250);


            // RelationShip 1 -n
            builder.HasOne(x => x.Category ).WithMany(x => x.CategoriesDetail).HasForeignKey(x => x.Categories_id);
            builder.HasOne(x => x.Post ).WithMany(x => x.CategoriesDetail).HasForeignKey(x => x.Post_id );

        }
    }
}
