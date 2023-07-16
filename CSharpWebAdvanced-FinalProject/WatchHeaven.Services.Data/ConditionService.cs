using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Condition;

namespace WatchHeaven.Services.Data
{
    public class ConditionService : IConditionService
    {
        private readonly WatchHeavenDbContext dbContext;

        public ConditionService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WatchSelectConditionFormModel>> GetAllConditionsAsync()
        {
            IEnumerable<WatchSelectConditionFormModel> allConditions = await this.dbContext
                .Conditions
                .AsNoTracking()
                .Select (condition => new WatchSelectConditionFormModel
                {
                    Id = condition.Id,
                    Name = condition.Name,
                })
                .ToArrayAsync();

            return allConditions;
        }
    }
}
