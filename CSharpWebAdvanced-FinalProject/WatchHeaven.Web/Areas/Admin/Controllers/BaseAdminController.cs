using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static WatchHeaven.Common.GeneralApplicationConstants;
namespace WatchHeaven.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
    }
}
