using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WatchHeaven.Web.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        public async Task<IActionResult> BecomeSeller()
        {
            return View();
        }
    }
}
