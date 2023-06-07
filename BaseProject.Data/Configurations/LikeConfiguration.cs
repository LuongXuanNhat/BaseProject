using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostId).HasDefaultValue(0);

            builder.HasOne(x => x.User).WithMany(x => x.Like).HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post).WithMany(x => x.Likess).HasForeignKey(x => x.PostId);



        }

    }
}
