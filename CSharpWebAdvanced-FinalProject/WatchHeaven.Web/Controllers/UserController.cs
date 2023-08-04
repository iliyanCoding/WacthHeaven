using Griesoft.AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Data.Model;
using WatchHeaven.Web.ViewModels.User;
using static WatchHeaven.Common.NotificationMessageConstants;

namespace WatchHeaven.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, 
                              UserManager<ApplicationUser> userManager,
                              IUserStore<ApplicationUser> userStore) 
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
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
    }
}
