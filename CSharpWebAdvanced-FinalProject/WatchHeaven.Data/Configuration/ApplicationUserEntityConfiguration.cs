
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchHeaven.Data.Model;

namespace WatchHeaven.Data.Configuration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .HasDefaultValue("FirstNameTest");

            builder.Property(u => u.LastName)
                .HasDefaultValue("LastNameTest");
        }
    }
}
