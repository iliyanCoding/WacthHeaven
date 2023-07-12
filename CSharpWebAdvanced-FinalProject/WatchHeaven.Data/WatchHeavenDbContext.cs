using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using WatchHeaven.Data.Model;

namespace WatchHeaven.Web.Data
{
    public class WatchHeavenDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public WatchHeavenDbContext(DbContextOptions<WatchHeavenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Condition> Conditions { get; set; } = null!;

        public DbSet<Seller> Sellers { get; set; } = null!;

        public DbSet<Watch> Watches { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            Assembly configAssembly = Assembly.GetAssembly(typeof(WatchHeavenDbContext)) ??
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}