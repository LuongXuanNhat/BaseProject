using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SearchConfiguration : IEntityTypeConfiguration<Search>
    {
        public void Configure(EntityTypeBuilder<Search> builder)
        {
            builder.ToTable("Searchs");

            builder.HasKey(x => x.Search_id);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(250);

        }
    }
}
