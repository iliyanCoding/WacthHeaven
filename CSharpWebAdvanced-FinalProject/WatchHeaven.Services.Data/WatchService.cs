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

        public async Task<IEnumerable<IndexViewModel>> MostExpensiveWatchesAsync()
        {
            IEnumerable<IndexViewModel>? mostExpensiveWatches = await this.dbContext
                .Watches
                .OrderByDescending(w => w.Price)
                .Take(4)
                .Select(w => new IndexViewModel
                {
                    Id = w.Id.ToString(),
                    Brand = w.Brand,
                    Model = w.Model,
                    ImageUrl = w.ImageUrl,
                })
                .ToArrayAsync();

            return mostExpensiveWatches;
                
        }
    }
}
