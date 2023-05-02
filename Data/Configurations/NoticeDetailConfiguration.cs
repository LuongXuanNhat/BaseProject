using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class NoticeDetailConfiguration : IEntityTypeConfiguration<NoticeDetail>
    {
        public void Configure(EntityTypeBuilder<NoticeDetail> builder)
        {
            builder.ToTable("NoticeDetails");

            builder.HasKey(x => new { x.NotificationId, x.UserId });
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);


            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.NoticeDetail).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Notification).WithMany(x => x.NoticeDetail).HasForeignKey(x => x.NotificationId);
        }
    }
}
