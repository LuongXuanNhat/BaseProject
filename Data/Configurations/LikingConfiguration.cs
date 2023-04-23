using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class LikingConfiguration : IEntityTypeConfiguration<Liking>
    {
        public void Configure(EntityTypeBuilder<Liking> builder)
        {
            builder.ToTable("Likings");

            builder.HasKey(x => x.Id);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Liking).HasForeignKey(x => x.User_id);
            builder.HasOne(x => x.Post).WithMany(x => x.Liking).HasForeignKey(x => x.Post_id);
            builder.HasOne(x => x.Comment).WithMany(x => x.Liking).HasForeignKey(x => x.Comment_id);
        }

    }
}
