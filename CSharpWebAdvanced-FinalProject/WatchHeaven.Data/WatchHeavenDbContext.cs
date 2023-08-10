using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using WatchHeaven.Data.Configuration;
using WatchHeaven.Data.Model;

namespace WatchHeaven.Web.Data
{
    public class WatchHeavenDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public WatchHeavenDbContext(DbContextOptions<WatchHeavenDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Condition> Conditions { get; set; } = null!;

        public DbSet<Seller> Sellers { get; set; } = null!;

        public DbSet<Watch> Watches { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserFavoriteWatch>()
            .HasKey(ufw => new { ufw.UserId, ufw.WatchId });

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            builder.ApplyConfiguration(new WatchEntityConfiguration());
            if (this.seedDb)
            {
                builder.ApplyConfiguration(new CategoryEntityConfiguration());
                builder.ApplyConfiguration(new ConditionEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}