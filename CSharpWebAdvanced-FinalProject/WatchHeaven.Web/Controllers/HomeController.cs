using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.ViewModels.Home;

namespace WatchHeaven.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWatchService watchService; 

        public HomeController(IWatchService watchService)
        {
            this.watchService = watchService; 
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel viewModel = await this.watchService.MostExpensiveWatchAsync();
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}