using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Stars).IsRequired();


            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Rating).HasForeignKey(x => x.User_id);
            builder.HasOne(x => x.Post).WithMany(x => x.Rating).HasForeignKey(x => x.Post_id);
        }

    }
}
