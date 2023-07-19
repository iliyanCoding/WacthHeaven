using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Category;
using WatchHeaven.Web.ViewModels.Condition;

namespace WatchHeaven.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly WatchHeavenDbContext dbContext;

        public CategoryService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int categoryId)
        {
            bool result = await this.dbContext.Categories.AnyAsync(c => c.Id == categoryId);
            return result; 
        }

        public async Task<IEnumerable<WatchSelectCategoryFormModel>> GetAllCategoriesAsync()
        {
            IEnumerable<WatchSelectCategoryFormModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(category => new WatchSelectCategoryFormModel
                {
                    Id = category.Id,
                    Name = category.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
