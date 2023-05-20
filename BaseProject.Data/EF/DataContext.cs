using BaseProject.Data.Configurations;
using BaseProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BaseProject.Data.EF
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.;Database=BaseProject2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration using fluent API

            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesDetailConfiguration());

            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new LocationsDetailConfiguration());

            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NoticeDetailConfiguration());

            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new LikingConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ShareConfiguration());
            modelBuilder.ApplyConfiguration(new SavedConfiguration());
            modelBuilder.ApplyConfiguration(new FollowingConfiguration());
            modelBuilder.ApplyConfiguration(new SearchConfiguration());
            modelBuilder.ApplyConfiguration(new RatingLocationConfiguration());

            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


            base.OnModelCreating(modelBuilder);
            new SeedData(modelBuilder).Seed();
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<CategoriesDetail> CategoriesDetails { set; get; }
        public DbSet<Location> Locations { set; get; }
        public DbSet<LocationsDetail> LocationsDetails { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Rating> Ratings { set; get; }
        public DbSet<Liking> Likings { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<Saved> Saveds { set; get; }
        public DbSet<Share> Shares { set; get; }
        public DbSet<Search> Searches { set; get; }
        public DbSet<Following> Followings { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<NoticeDetail> NoticeDetails { set; get; }
        public DbSet<Image> Images { set; get; }
        public DbSet<Video> Videos { set; get; }
        public DbSet<RatingLocation> RatingLocations { set; get; }

    }
}
