using Griesoft.AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WatchHeaven.Data.Model;
using WatchHeaven.Web.ViewModels.User;
using static WatchHeaven.Common.NotificationMessageConstants;
using static WatchHeaven.Common.GeneralApplicationConstants;
using WatchHeaven.Web.Infrastructure.Extensions;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data;

namespace WatchHeaven.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IMemoryCache memoryCache;
        private readonly IUserService userService;
        private readonly IWatchService watchService;

        public UserController(SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IUserStore<ApplicationUser> userStore,
                              IMemoryCache memoryCache,
                              IUserService userService,
                              IWatchService watchService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
            this.memoryCache = memoryCache;
            this.userService = userService;
            this.watchService = watchService;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
            };

            await this.userManager.SetEmailAsync(user, formModel.Email);
            await this.userManager.SetUserNameAsync(user, formModel.Email);

            IdentityResult result = await this.userManager.CreateAsync(user, formModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(formModel);
            }

            await this.signInManager.SignInAsync(user, false);
            this.memoryCache.Remove(UsersCacheKey);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormViewModel viewModel = new LoginFormViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateRecaptcha(Action = nameof(Register), ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Login(LoginFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result =
                await this.signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured. Please try again later or contact administrator.";
                return View(viewModel);
            }

            return Redirect(viewModel.ReturnUrl ?? "/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(string id)
        {
            var userId = User.GetId();

            var success = await userService.AddWatchToFavoritesAsync(userId, id);

            if (!success)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured. Please try again later or contact administrator.";
                return View();
            }

            this.TempData[SuccessMessage] = "You added this watch to your favorites";
            return RedirectToAction("Details", "Watch", new { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(string id)
        {
            var userId = User.GetId();

            if (await userService.IsWatchInFavoritesAsync(userId, id))
            {
                await userService.RemoveFromFavoritesAsync(userId, id);
            }

            return RedirectToAction("Favorite", "User", new { id });
        }

        public async Task<IActionResult> Favorite()
        {
            var userId = User.GetId(); // Get the user's ID
            var favoriteWatches = await watchService.GetFavoriteWatchesAsync(userId);
            return View("Favorite", favoriteWatches);
        }
    }
}
