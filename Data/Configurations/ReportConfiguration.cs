using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(100);



            // Relationship
            builder.HasOne(x => x.User).WithMany(x => x.Report).HasForeignKey(x => x.User_id);
            builder.HasOne(x => x.Post).WithMany(x => x.Report).HasForeignKey(x => x.Post_id);
            builder.HasOne(x => x.Comment).WithMany(x => x.Report).HasForeignKey(x => x.Comment_id);
        }
    }
}
