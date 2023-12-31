﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.ViewModels.Home;
using static WatchHeaven.Common.GeneralApplicationConstants;

namespace WatchHeaven.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWatchService watchService; 

        public HomeController(IWatchService watchService)
        {
            this.watchService = watchService; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new {Area = AdminRoleName});
            }

            IEnumerable<IndexViewModel> viewModel = await this.watchService.MostExpensiveWatchesAsync();
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404 || statusCode == 400)
            {
                return this.View("Error404");
            }
            return View();
        }
    }
}