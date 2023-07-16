using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Infrastructure.Extensions;
using WatchHeaven.Web.ViewModels.Seller;
using static WatchHeaven.Common.NotificationMessageConstants;

namespace WatchHeaven.Web.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeSeller()
        {
            string userId = this.User.GetId();
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(userId);
            if (isSeller)
            {
                TempData[ErrorMessage] = "You are already a seller";
                return this.RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomeSeller(BecomeSellerFormModel model)
        {
            string userId = this.User.GetId();
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(userId);
            if (isSeller)
            {
                TempData[ErrorMessage] = "You are already a seller";
                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberUsed = await this.sellerService.SellerExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberUsed)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with this phone number already exists!");
            }

            bool isAddressUsed = await this.sellerService.SellerExistsByAddressAsync(model.Address);

            if (isAddressUsed)
            {
                ModelState.AddModelError(nameof(model.Address), "Seller with this address already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.sellerService.CreateSellerAsync(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "Watch");
        }
    }
}
