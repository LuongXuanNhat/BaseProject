using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class FollowingConfiguration : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.ToTable("Followings");

            builder.HasKey(x => new {x.Follower_id, x.Followee_id});


            // RelationShip 1 -n
            builder.HasOne(x => x.Follower).WithMany(x => x.Followee).HasForeignKey(x => x.Follower_id);
            builder.HasOne(x => x.Followee).WithMany(x => x.Follower).HasForeignKey(x => x.Followee_id);
            


        }
    }
}
