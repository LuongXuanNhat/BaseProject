using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class ShareConfiguration : IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.ToTable("Shares");

            builder.HasKey(x => x.Id);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Share).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Share).HasForeignKey(x => x.PostId);
        }
    }
}
