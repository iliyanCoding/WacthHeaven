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
    public class ConditionEntityConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasData(this.GenerateConditions());
        }

        private Condition[] GenerateConditions()
        {
            ICollection<Condition> conditions = new HashSet<Condition>();

            Condition condition;

            condition = new Condition() 
            {
                Id = 1,
                Name = "New",
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 2,
                Name = "Very good",
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 3,
                Name = "Good",
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 4,
                Name = "Fair",
            };
            conditions.Add(condition);

            return conditions.ToArray();
        }
    }
}
