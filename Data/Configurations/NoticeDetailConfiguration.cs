using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class NoticeDetailConfiguration : IEntityTypeConfiguration<NoticeDetail>
    {
        public void Configure(EntityTypeBuilder<NoticeDetail> builder)
        {
            builder.ToTable("NoticeDetails");

            builder.HasKey(x => new { x.Notification_id, x.User_id });
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(1000);
        }
    }
}
