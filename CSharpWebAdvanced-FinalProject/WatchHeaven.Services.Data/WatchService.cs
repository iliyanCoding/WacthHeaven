using Microsoft.EntityFrameworkCore;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Home;
using WatchHeaven.Web.ViewModels.Watch;

namespace WatchHeaven.Services.Data
{
    public class WatchService : IWatchService
    {
        private readonly WatchHeavenDbContext dbContext;

        public WatchService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(WatchFormViewModel model, string sellerId)
        {
            Watch watch = new Watch() 
            {
                Brand = model.Brand,
                Model = model.Model,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ConditionId = model.ConditionId,
                SellerId = Guid.Parse(sellerId)
            };

            await this.dbContext.Watches.AddAsync(watch);
            await this.dbContext.SaveChangesAsync();
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
