using BaseProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProject.Data.Configurations
{
    public class QAConfiguration : IEntityTypeConfiguration<QuestionAndAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAndAnswer> builder)
        {
            builder.ToTable("QuestionAndAnswers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuestionId).HasDefaultValue(0);
            builder.Property(x => x.UserName).IsRequired(false);
            builder.Property(x => x.Date).IsRequired(false);
            builder.Property(x => x.MessageText).IsRequired(false);

            builder.HasOne(x => x.location).WithMany(x => x.QuestionAndAnswers).HasForeignKey(x => x.LocationId);



        }

    }
}
