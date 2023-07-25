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
        public async Task<IActionResult> All([FromQuery] AllWatchesQueryModel queryModel)
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

            if (!isSeller)
            {
                this.TempData[ErrorMessage] = "You must be a Seller in order to add a watch for sale!";

                return this.RedirectToAction("BecomeSeller", "Seller");
            }

            try
            {
                WatchFormViewModel formViewModel = new WatchFormViewModel()
                {
                    Categories = await this.categoryService.GetAllCategoriesAsync(),
                    Conditions = await this.conditionService.GetAllConditionsAsync()
                };

                return View(formViewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

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
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(formModel.CategoryId), "The category you have selected does not exists!");
            }

            bool conditionExists = await this.conditionService.ExistsByIdAsync(formModel.ConditionId);
            if (!conditionExists)
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

                string watchId = await this.watchService.CreateAsync(formModel, sellerId!);

                this.TempData[SuccessMessage] = "The watch was added successfully";
                return this.RedirectToAction("Details", "Watch", new { id = watchId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured! Please try again later or contact administrator!");
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();

                return View(formModel);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool exists = await this.watchService.ExistsByIdAsync(id);
            if (!exists)
            {
                this.TempData[ErrorMessage] = "Watch with this id does not exist!";
                return RedirectToAction("All", "Watch");
            }

            try
            {
                WatchDetailsViewModel viewModel = await this.watchService
                .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool exists = await this.watchService.ExistsByIdAsync(id);
            if (!exists)
            {
                this.TempData[ErrorMessage] = "Watch with this id does not exist!";
                return RedirectToAction("All", "Watch");
            }

            bool isUserSeller = await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to edit the watch information!";
                return RedirectToAction("BecomeSeller", "Seller");
            }

            string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId());

            bool isSellerOwner = await this.watchService.IsSellerWithIdOwnerofWatchWithIdAsync(sellerId!, id);

            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the seller of this watch in order to edit the watch information";

                return RedirectToAction("Mine", "Watch");
            }

            try
            {
                WatchFormViewModel formModel = await this.watchService.GetWatchForEditByIdAsync(id);
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, WatchFormViewModel formModel)
        {
            if (!this.ModelState.IsValid)
            {
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();
                return this.View(formModel);
            }

            bool exists = await this.watchService.ExistsByIdAsync(id);
            if (!exists)
            {
                this.TempData[ErrorMessage] = "Watch with this id does not exist!";
                return RedirectToAction("All", "Watch");
            }

            bool isUserSeller = await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to edit the watch information!";
                return RedirectToAction("BecomeSeller", "Seller");
            }

            string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId());

            bool isSellerOwner = await this.watchService.IsSellerWithIdOwnerofWatchWithIdAsync(sellerId!, id);

            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the seller of this watch in order to edit the watch information";

                return RedirectToAction("Mine", "Watch");
            }

            try
            {
                await this.watchService.EditWatchByIdAndFormModelAsync(id, formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator!";
                formModel.Categories = await this.categoryService.GetAllCategoriesAsync();
                formModel.Conditions = await this.conditionService.GetAllConditionsAsync();

                return View(formModel);
            }

            this.TempData[SuccessMessage] = "The watch was edited successfully";
            return this.RedirectToAction("Details", "Watch", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool exists = await this.watchService.ExistsByIdAsync(id);
            if (!exists)
            {
                this.TempData[ErrorMessage] = "Watch with this id does not exist!";
                return RedirectToAction("All", "Watch");
            }

            bool isUserSeller = await this.sellerService.SellerExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserSeller)
            {
                this.TempData[ErrorMessage] = "You must be a seller in order to edit the watch information!";
                return RedirectToAction("BecomeSeller", "Seller");
            }

            string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId());

            bool isSellerOwner = await this.watchService.IsSellerWithIdOwnerofWatchWithIdAsync(sellerId!, id);

            if (!isSellerOwner)
            {
                this.TempData[ErrorMessage] = "You must be the seller of this watch in order to edit the watch information";

                return RedirectToAction("Mine", "Watch");
            }

            try
            {
                WatchDeleteDetailsViewModel viewModel = await this.watchService.GetWatchForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<WatchAllViewModel> myWatches = new List<WatchAllViewModel>();

            string userId = this.User.GetId()!;

            bool isUserSeller = await this.sellerService.SellerExistsByUserIdAsync(userId);

            if (isUserSeller)
            {
                string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(userId);
               
                myWatches.AddRange(await this.watchService.AllBySellerIdAsync(sellerId!));
            }

            return View(myWatches);
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator!";

            return RedirectToAction("Index", "Home");
        }
    }
}
