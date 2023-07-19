using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data.Models.Watch;
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
        private readonly IWatchService watchService;

        public WatchController(ICategoryService categorySerivce, IConditionService conditionService, ISellerService sellerService, IWatchService watchService)
        {
            this.categoryService = categorySerivce;
            this.conditionService = conditionService;
            this.sellerService = sellerService;
            this.watchService = watchService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllWatchesQueryModel queryModel)
        {
            AllWatchesFilteredAndPagedServiceModel serviceModel = await this.watchService.AllAsync(queryModel);

            queryModel.Watches = serviceModel.Watches;
            queryModel.TotalWatches = serviceModel.TotalWatchesCount;
            queryModel.Categories = await this.categoryService.AllCategoriesNamesAsync();
            queryModel.Conditions = await this.conditionService.AllConditionsNamesAsync();

            return this.View(queryModel);
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

        [HttpPost]
        public async Task<IActionResult> AddWatch(WatchFormViewModel formModel)
        {
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must be a Seller in order to add a watch for sale!";

                return this.RedirectToAction("BecomeSeller", "Seller");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(formModel.CategoryId);
            if(!categoryExists)
            {
                ModelState.AddModelError(nameof(formModel.CategoryId), "The category you have selected does not exists!");
            }

            bool conditionExists = await this.conditionService.ExistsByIdAsync(formModel.ConditionId);
            if(!conditionExists)
            {
                ModelState.AddModelError(nameof(formModel.ConditionId), "The condition you have selected does not exists!");
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();

                return View(formModel);
            }

            try
            {
                string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);

                await this.watchService.CreateAsync(formModel, sellerId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured! Please try again later or contact administrator!");
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();

                return View(formModel);
            }

            return this.RedirectToAction("All", "Watch");
        }
    }
}
