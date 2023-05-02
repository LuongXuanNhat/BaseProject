using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class SearchConfiguration : IEntityTypeConfiguration<Search>
    {
        public void Configure(EntityTypeBuilder<Search> builder)
        {
            builder.ToTable("Searchs");

            builder.HasKey(x => x.SearchId);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(250);


            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Search).HasForeignKey(x => x.UserId);
        }

    }
}
