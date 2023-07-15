using Microsoft.EntityFrameworkCore;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Home;

namespace WatchHeaven.Services.Data
{
    public class WatchService : IWatchService
    {
        private readonly WatchHeavenDbContext dbContext;

        public WatchService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IndexViewModel> MostExpensiveWatchAsync()
        {
            IndexViewModel? mostExpensiveWatche = await this.dbContext
                .Watches
                .OrderByDescending(w => w.Price)
                .Select(w => new IndexViewModel
                {
                    Id = w.Id.ToString(),
                    Brand = w.Brand,
                    Model = w.Model,
                    ImageUrl = w.ImageUrl,
                })
                .FirstOrDefaultAsync();

            return mostExpensiveWatche;
                
        }
    }
}
