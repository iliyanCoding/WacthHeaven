using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Category;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<WatchSelectCategoryFormModel>> GetAllCategoriesAsync();

        Task<bool> ExistsByIdAsync(int categoryId);
    }
}
