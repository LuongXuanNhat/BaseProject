using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class SavedConfiguration : IEntityTypeConfiguration<Saved>

    {
        public void Configure(EntityTypeBuilder<Saved> builder)
        {
            builder.ToTable("Saveds");

            builder.HasKey(x => x.Id);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Saved).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Saved).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Location).WithMany(x => x.Saved).HasForeignKey(x => x.LocationId);
        }
    }
}
