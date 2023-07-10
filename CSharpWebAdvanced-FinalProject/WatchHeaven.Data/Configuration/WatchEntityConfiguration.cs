using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;

namespace WatchHeaven.Data.Configuration
{
    public class WatchEntityConfiguration : IEntityTypeConfiguration<Watch>
    {
        public void Configure(EntityTypeBuilder<Watch> builder)
        {
            builder
                .HasOne(w => w.Category)
                .WithMany(c => c.Watches)
                .HasForeignKey(w => w.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(w => w.Condition)
                .WithMany(c => c.Watches)
                .HasForeignKey(w => w.ConditionId);

            builder
                  .HasOne(w => w.Seller)
                .WithMany(s => s.OwnedWatches)
                .HasForeignKey(w => w.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
