using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.ViewModels.Category;

namespace WatchHeaven.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllCategoriesViewModel> viewModel = await this.categoryService.AllCategoriesForListAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            
        }
    }
}
