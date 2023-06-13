using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class NoticeDetailConfiguration : IEntityTypeConfiguration<NoticeDetail>
    {
        public void Configure(EntityTypeBuilder<NoticeDetail> builder)
        {
            builder.ToTable("NoticeDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.IsRead).HasDefaultValue(YesNo.no);

            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.NoticeDetail).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Notification).WithMany(x => x.NoticeDetail).HasForeignKey(x => x.NotificationId);
        }
    }
}
