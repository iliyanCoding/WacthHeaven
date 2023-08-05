using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.ViewModels.User;

namespace WatchHeaven.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
