using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Infrastructure.Extensions;
using WatchHeaven.Web.ViewModels.Watch;
using static WatchHeaven.Common.NotificationMessageConstants;

namespace WatchHeaven.Web.Controllers
{
    [Authorize]
    public class WatchController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IConditionService conditionService;
        private readonly ISellerService sellerService;

        public WatchController(ICategoryService categorySerivce, IConditionService conditionService, ISellerService sellerService)
        {
            this.categoryService = categorySerivce;
            this.conditionService = conditionService;
            this.sellerService = sellerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddWatch()
        {
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if(!isSeller)
            {
                this.TempData[ErrorMessage] = "You must be a Seller in order to add a watch for sale!";

                return this.RedirectToAction("BecomeSeller", "Seller");
            }

            WatchFormViewModel formViewModel = new WatchFormViewModel()
            {
                Categories = await this.categoryService.GetAllCategoriesAsync(),
                Conditions = await this.conditionService.GetAllConditionsAsync()
            };

            return View(formViewModel);
        }
    }
}
