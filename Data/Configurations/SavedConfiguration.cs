using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class SavedConfiguration : IEntityTypeConfiguration<Saved>

    {
        public void Configure(EntityTypeBuilder<Saved> builder)
        {
            builder.ToTable("Saveds");

            builder.HasKey(x => x.Id);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Saved).HasForeignKey(x => x.User_id);
            builder.HasOne(x => x.Post).WithMany(x => x.Saved).HasForeignKey(x => x.Post_id);
        }
    }
}
