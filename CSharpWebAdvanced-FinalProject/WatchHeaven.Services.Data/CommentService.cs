using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Comment;

namespace WatchHeaven.Services.Data
{
    public class CommentService : ICommentService
    {
        private readonly WatchHeavenDbContext dbContext;

        public CommentService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<CommentViewModel>> GetAllCommentsForWatchAsync(string watchId)
        {
            var comments = await dbContext.Comments
                .Where(c => c.WatchId.ToString() == watchId && c.IsActive)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    UserName = c.User.UserName,
                    CommentedOn = c.CommentedOn,
                    UserId = c.UserId,
                    WatchId = c.WatchId
                })
                .ToListAsync();

            return comments;
        }

        public async Task AddCommentAsync(string watchId, string userId, string text)
        {
            var comment = new Comment
            {
                WatchId = Guid.Parse(watchId),
                UserId = Guid.Parse(userId),
                Text = text,
                CommentedOn = DateTime.UtcNow,
                IsActive = true
            };

            dbContext.Comments.Add(comment);
            await dbContext.SaveChangesAsync();
        }
    }
}
