using WatchHeaven.Web.ViewModels.Comment;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface ICommentService
    {
        Task<ICollection<CommentViewModel>> GetAllCommentsForWatchAsync(string watchId);

        Task AddCommentAsync(string watchId, string userId, string text);
    }
}
