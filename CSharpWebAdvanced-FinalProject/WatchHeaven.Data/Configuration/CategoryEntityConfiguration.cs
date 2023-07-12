using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;

namespace WatchHeaven.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Chronograph"
            };
            categories.Add(category);

            category = new Category() 
            { 
                Id = 2,
                Name = "Vintage"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Diving"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Pilot's"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Military"
            };
            categories.Add(category);


            return categories.ToArray();
        }
    }
}
