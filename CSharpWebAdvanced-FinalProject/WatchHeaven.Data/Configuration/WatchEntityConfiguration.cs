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
            builder.Property(w => w.AddedOn)
                   .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(w => w.Category)
                .WithMany(c => c.Watches)
                .HasForeignKey(w => w.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(w => w.Condition)
                .WithMany(c => c.Watches)
                .HasForeignKey(w => w.ConditionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                  .HasOne(w => w.Seller)
                .WithMany(s => s.OwnedWatches)
                .HasForeignKey(w => w.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateWatches());
        }

        private Watch[] GenerateWatches()
        {
            ICollection<Watch> watches = new HashSet<Watch>();

            Watch watch;

            watch = new Watch()
            {
                Brand = "Universal Geneve",
                Model = "Aero-Compax",
                Description = "This is an extremely rare and fine example of the Universal Genève Aero-Compax model in stainless steel from 1945. The watch measures 38mm in diameter and 14mm thick, which is a very large case for the period in which it was produced. By comparison, Patek Phillipe chronographs from the 1940s measured 33.3mm in diameter. These generous dimensions and the screw-in waterproof back give the watch a contemporary tool-watch feel with the charm of a 75-year-old timepiece. The incorporation of the Arabic numbers and luminous dial make this example all the more collectible.",
                ImageUrl = "https://www.lesrhabilleurs.com/wp-content/uploads/2020/03/universal-geneve-compax-nina-rindt-3-1920x980.jpg",
                Price = 17500.00M,
                CategoryId = 2,
                ConditionId = 3,
                SellerId = Guid.Parse("498A11DB-2703-49DB-BD42-CC4F3542EA9A")
            };
            watches.Add(watch);

            watch = new Watch()
            {
                Brand = "IWC Portuguese Chronograph",
                Model = "iw371415",
                Description = "For Sale is the IWC Portuguese Chrono IW3714-15 Rose Gold 41MM Men's Watch. The watch comes with everything pictured. Purchased directly from a private collector, MINT condition. If you have any questions regarding condition please contact us, don't assume anything. Thank you",
                ImageUrl = "https://images.watchfinder.co.uk/imgv2/stock/175737/IWC-PortugueseChrono-IW371415-175737-1-210107-101106.jpg",
                Price = 9995.00M,
                CategoryId = 1,
                ConditionId = 2,
                SellerId = Guid.Parse("498A11DB-2703-49DB-BD42-CC4F3542EA9A")
            };
            watches.Add(watch);

            watch = new Watch()
            {
                Brand = "Seiko",
                Model = "Prospex",
                Description = "BNIB Seiko Prospex Marinemaster Diver Limited to 3,000 pieces\r\n\r\nRef.SLA047 - 44mm stainless steel case\r\n\r\nNever worn or sized - Stickered bracelet\r\n\r\nDouble boxed + Additional rubber strap + Instruction booklets + Open Warranty card\r\n\r\nFeel free to reach out with any questions. International buyers are responsible for import fees.",
                ImageUrl = "https://timeland.bg/media/catalog/product/cache/4de58d8aef055b2740ac5de0bb342903/s/r/srpj35k1.png",
                Price = 3200.00M,
                CategoryId = 3,
                ConditionId = 1,
                SellerId = Guid.Parse("bc37c605-d12f-4a25-a0e9-57d2b75d5b97")
            };
            watches.Add(watch);

            watch = new Watch()
            {
                Brand = "Breitling",
                Model = "Navitimer World",
                Description = "Breitling Navitimer\r\n46mm Stainless Steel\r\nRotating Bezel, Steel Bracelet\r\nBlue Dial\r\nModel A2432212/C651\r\nMINT CONDITION!\r\n---Additional Blue Leather Strap with Deployment\r\nIncluded with the watch:\r\n-Breitling box\r\n-Breitling warranty papers dated April 2018\r\n-Manual\r\n-2 Year warranty\r\n-Appraisal",
                ImageUrl = "https://www.giulian.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/r/breitling-navitimer-world.jpg",
                Price = 5995.00M,
                CategoryId = 4,
                ConditionId = 2,
                SellerId = Guid.Parse("bc37c605-d12f-4a25-a0e9-57d2b75d5b97")
            };
            watches.Add(watch);

            watch = new Watch()
            {
                Brand = "Zenith",
                Model = "Pilot",
                Description = "Side notes:\r\nThe watch was serviced in March 2023.\r\nThe watch has some signs of use but is in very good condition and is fully composed of Zenith pieces as you can see on the pictures.\r\n\r\nSECURITY: All watches are deposited in a bank safe! Personal check and pickup are not possible. I only deliver by mailorder\r\n\r\n- Worldwide shipping, please ask for shipping rates!\r\n- All watches are 100% authentic\r\nThanks!",
                ImageUrl = "https://pics.zeitauktion.com/2021/2107187_sw6_cover_full.jpg",
                Price = 775.00M,
                CategoryId = 5,
                ConditionId = 4,
                SellerId = Guid.Parse("498A11DB-2703-49DB-BD42-CC4F3542EA9A")
            };
            watches.Add(watch);

            return watches.ToArray();
        }
    }
}
