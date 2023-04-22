using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired(false);
            builder.Property(x => x.DateOfBir).IsRequired(false);
            builder.Property(x => x.Gender).IsRequired(false);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(500);

        }
    }
}
