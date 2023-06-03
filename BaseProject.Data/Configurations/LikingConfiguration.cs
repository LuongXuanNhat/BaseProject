using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class LikingConfiguration : IEntityTypeConfiguration<Liking>
    {
        public void Configure(EntityTypeBuilder<Liking> builder)
        {
            builder.ToTable("Likings");

            builder.HasKey(x => x.Id);




        }

    }
}
