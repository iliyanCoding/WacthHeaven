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

        public async Task<IEnumerable<string>> AllConditionsNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Conditions
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int conditionId)
        {
            bool result = await this.dbContext.Conditions.AnyAsync(c => c.Id == conditionId);
            return result;
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
