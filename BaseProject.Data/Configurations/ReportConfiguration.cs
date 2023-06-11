using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsRead).HasDefaultValue(YesNo.no);


            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Report).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post).WithMany(x => x.Report).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Comment).WithMany(x => x.Report).HasForeignKey(x => x.CommentId);
        }
    }
}
