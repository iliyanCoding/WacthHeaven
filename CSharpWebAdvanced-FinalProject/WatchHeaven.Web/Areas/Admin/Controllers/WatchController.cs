using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Areas.Admin.ViewModels.Watch;
using WatchHeaven.Web.Infrastructure.Extensions;

namespace WatchHeaven.Web.Areas.Admin.Controllers
{
    public class WatchController : BaseAdminController
    {
        private readonly IWatchService watchService;
        private readonly ISellerService sellerService;

        public WatchController(IWatchService watchService, ISellerService sellerService)
        {
            this.watchService = watchService;
            this.sellerService = sellerService;
        }
        public async Task<IActionResult> Mine()
        {
            string? sellerId = await this.sellerService.GetSellerIdByUserIdAsync(this.User.GetId()!);

            MyWatchesViewModel myWatches = new MyWatchesViewModel()
            {
                AddedWatches = await this.watchService.AllBySellerIdAsync(sellerId!),
            };

            return View(myWatches);
        }
    }
}
