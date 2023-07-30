using Microsoft.EntityFrameworkCore;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Services.Data.Models.Watch;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Home;
using WatchHeaven.Web.ViewModels.Seller;
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
                WatchSorting.Newest => watchesQuery.OrderByDescending(w => w.AddedOn),
                WatchSorting.Oldest => watchesQuery.OrderBy(w => w.AddedOn),
                WatchSorting.PriceAscending => watchesQuery.OrderBy(w => w.Price),
                WatchSorting.PriceDescending => watchesQuery.OrderByDescending(w => w.Price),
                _ => watchesQuery.OrderByDescending(w => w.AddedOn)
            };

            IEnumerable<WatchAllViewModel> allWatches = await watchesQuery
                .Where(w => w.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.WatchesPerPage)
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

        public async Task<IEnumerable<WatchAllViewModel>> AllBySellerIdAsync(string sellerId)
        {
            IEnumerable<WatchAllViewModel> allSellerWatches = await this.dbContext
                   .Watches
                   .Where(w => w.SellerId.ToString() == sellerId && 
                          w.IsActive)
                   .Select(w => new WatchAllViewModel()
                   {
                       Id = w.Id.ToString(),
                       Model = w.Model,
                       Brand = w.Brand,
                       ImageUrl= w.ImageUrl,
                       Price= w.Price
                   })
                   .ToArrayAsync();

            return allSellerWatches;
        }

        public async Task<string> CreateAsync(WatchFormViewModel model, string sellerId)
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

            return watch.Id.ToString();
        }

        public async Task DeleteWatchByIdAsync(string watchId)
        {
            Watch watch = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            watch.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditWatchByIdAndFormModelAsync(string watchId, WatchFormViewModel formModel)
        {
            Watch watch = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            watch.Brand = formModel.Brand;
            watch.Model = formModel.Model;
            watch.Description = formModel.Description;
            watch.ImageUrl = formModel.ImageUrl;
            watch.Price = formModel.Price;
            watch.CategoryId = formModel.CategoryId;
            watch.ConditionId = formModel.ConditionId;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string watchId)
        {
            bool result = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
                .AnyAsync(w => w.Id.ToString() == watchId);

            return result;
        }

        public async Task<WatchDetailsViewModel> GetDetailsByIdAsync(string watchId)
        {
            Watch? watch = await this.dbContext
                .Watches
                .Include(w => w.Category)
                .Include(w => w.Condition)
                .Include(w => w.Seller)
                .ThenInclude(s => s.User)
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            return new WatchDetailsViewModel()
            {
                Id = watch.Id.ToString(),
                Model = watch.Model,
                Brand = watch.Brand,
                ImageUrl= watch.ImageUrl,
                Price= watch.Price,
                Description = watch.Description,
                Category = watch.Category.Name,
                Condition = watch.Condition.Name,
                Seller = new SellerInfoOnWatchViewModel()
                {
                    Email = watch.Seller.User.Email,
                    PhoneNumber = watch.Seller.PhoneNumber
                }
            };
        }

        public async Task<WatchDeleteDetailsViewModel> GetWatchForDeleteByIdAsync(string watchId)
        {
            Watch watch = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            return new WatchDeleteDetailsViewModel()
            {
                Brand = watch.Brand,
                Model = watch.Model,
                ImageUrl = watch.ImageUrl,
            };
        }

        public async Task<WatchFormViewModel> GetWatchForEditByIdAsync(string watchId)
        {
            Watch? watch = await this.dbContext
                .Watches
                .Include(w => w.Category)
                .Include(w => w.Condition)
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            return new WatchFormViewModel()
            {
                Model = watch.Model,
                Brand = watch.Brand,
                ImageUrl = watch.ImageUrl,
                Price = watch.Price,
                Description = watch.Description,
                CategoryId = watch.CategoryId,
                ConditionId = watch.ConditionId,
            };
        }

        public async Task<bool> IsSellerWithIdOwnerofWatchWithIdAsync(string sellerId, string watchId)
        {
            Watch watch = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == watchId);

            return watch.SellerId.ToString() == sellerId;
        }

        public async Task<IEnumerable<IndexViewModel>> MostExpensiveWatchesAsync()
        {
            IEnumerable<IndexViewModel>? mostExpensiveWatches = await this.dbContext
                .Watches
                .Where(w => w.IsActive)
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
