using Microsoft.EntityFrameworkCore;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data.Models.Watch;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Home;
using WatchHeaven.Web.ViewModels.Watch;
using WatchHeaven.Web.ViewModels.Watch.Enums;

namespace WatchHeaven.Services.Data
{
    public class WatchService : IWatchService
    {
        private readonly WatchHeavenDbContext dbContext;

        public WatchService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllWatchesFilteredAndPagedServiceModel> AllAsync(AllWatchesQueryModel queryModel)
        {
            IQueryable<Watch> watchesQuery = this.dbContext
                .Watches
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category) && !string.IsNullOrWhiteSpace(queryModel.Condition))
            {
                watchesQuery = watchesQuery
                    .Where(w => w.Condition.Name == queryModel.Condition && w.Category.Name == queryModel.Category);
            }
            else if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                watchesQuery = watchesQuery
                    .Where(w => w.Category.Name == queryModel.Category);
            }
            else if (!string.IsNullOrWhiteSpace(queryModel.Condition))
            {
                watchesQuery = watchesQuery
                    .Where(w => w.Condition.Name == queryModel.Condition);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                watchesQuery = watchesQuery
                    .Where(w => EF.Functions.Like(w.Brand, wildCard) ||
                                EF.Functions.Like(w.Model, wildCard) ||
                                EF.Functions.Like(w.Description, wildCard));
            }

            watchesQuery = queryModel.WatchSorting switch
            {
                WatchSorting.Newest => watchesQuery.OrderBy(w => w.AddedOn),
                WatchSorting.Oldest => watchesQuery.OrderByDescending(w => w.AddedOn),
                WatchSorting.PriceAscending => watchesQuery.OrderBy(w => w.Price),
                WatchSorting.PriceDescending => watchesQuery.OrderByDescending(w => w.Price),
                _ => watchesQuery.OrderByDescending(w => w.AddedOn)
            };

            IEnumerable<WatchAllViewModel> allWatches = await watchesQuery.
                Skip((queryModel.CurrentPage - 1) * queryModel.WatchesPerPage)
                .Take(queryModel.WatchesPerPage)
                .Select(w => new WatchAllViewModel
                {
                    Id = w.Id.ToString(),
                    Brand = w.Brand,
                    Model = w.Model,
                    ImageUrl = w.ImageUrl,
                    Price = w.Price,
                })
                .ToArrayAsync();

            int totalWatches = watchesQuery.Count();

            return new AllWatchesFilteredAndPagedServiceModel()
            {
                TotalWatchesCount = totalWatches,
                Watches = allWatches
            };
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
