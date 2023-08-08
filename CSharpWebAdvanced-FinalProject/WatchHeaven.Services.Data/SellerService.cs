using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.Seller;

namespace WatchHeaven.Services.Data
{
    public class SellerService : ISellerService
    {
        private readonly WatchHeavenDbContext dbContext;

        public SellerService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateSellerAsync(string userId, BecomeSellerFormModel model)
        {
            Seller seller = new Seller() 
            {
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Sellers.AddAsync(seller);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetSellerIdByUserIdAsync(string userId)
        {
            Seller? seller = await this.dbContext
                .Sellers
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (seller == null)
            {
                return null;
            }

            return seller.Id.ToString();
        }

        public async Task<bool> HasWatchWithIdAsync(string userId, string watchId)
        {
            Seller? seller = await dbContext
                .Sellers
                .Include(a => a.OwnedWatches)
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);
            if (seller == null)
            {
                return false;
            }

            watchId = watchId.ToLower();
            return seller.OwnedWatches.Any(h => h.Id.ToString() == watchId);
        }

        public async Task<bool> SellerExistsByAddressAsync(string address)
        {
            bool result = await this.dbContext
                .Sellers
                .AnyAsync(s => s.Address == address);

            return result;
        }

        public async Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                .Sellers
                .AnyAsync(s => s.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> SellerExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Sellers
                .AnyAsync(s => s.UserId.ToString() == userId);

            return result;
        }
    }
}
