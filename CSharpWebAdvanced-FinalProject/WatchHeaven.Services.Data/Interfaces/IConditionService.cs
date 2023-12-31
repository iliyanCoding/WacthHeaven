﻿using WatchHeaven.Web.ViewModels.Condition;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface IConditionService
    {
        Task<IEnumerable<WatchSelectConditionFormModel>> GetAllConditionsAsync();

        Task<bool> ExistsByIdAsync(int conditionId);

        Task<IEnumerable<string>> AllConditionsNamesAsync();
    }
}
