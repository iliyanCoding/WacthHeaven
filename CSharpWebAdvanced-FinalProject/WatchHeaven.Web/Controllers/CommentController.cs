using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchHeaven.Services.Data;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Infrastructure.Extensions;
using WatchHeaven.Web.ViewModels.Home;
using static WatchHeaven.Common.NotificationMessageConstants;

namespace WatchHeaven.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task<IActionResult> Comments(string watchId)
        {
            if (string.IsNullOrEmpty(watchId))
            {
                this.TempData[ErrorMessage] = "Invalid watch id";
                return RedirectToAction("Details", "Watch", new { id = watchId });
            }

            try
            {
                var comments = await commentService.GetAllCommentsForWatchAsync(watchId);

                // Pass the comments to the view
                return View(comments);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred. Pleaase try again later or contact administrator";
                return RedirectToAction("Details", "Watch", new { id = watchId });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string watchId, string commentText)
        {
            var userId = this.User.GetId();

            await commentService.AddCommentAsync(watchId, userId, commentText);
            this.TempData["SuccessMessage"] = "Comment added successfully!";
            return RedirectToAction("Details", "Watch", new { id = watchId });
        }

    }
}
