using Microsoft.AspNetCore.Mvc;

namespace WatchHeaven.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
