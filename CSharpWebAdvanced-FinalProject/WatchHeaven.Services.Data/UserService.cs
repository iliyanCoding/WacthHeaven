using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;
using WatchHeaven.Web.ViewModels.User;

namespace WatchHeaven.Services.Data
{
    public class UserService : IUserService
    {
        private readonly WatchHeavenDbContext dbContext;

        public UserService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddWatchToFavoritesAsync(string userId, string watchId)
        {

            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                // User not found
                return false;
            }

            var watch = await dbContext.Watches
                .FirstOrDefaultAsync(w => w.Id.ToString() == watchId);

            if (watch == null)
            {
                // Watch not found
                return false;
            }

            user.FavoriteWatches.Add(watch);

            try
            {
                dbContext.Entry(user).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                // Handle the exception as needed
                return false;
            }




        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            List<UserViewModel> users = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                })
                .ToListAsync();

            foreach (UserViewModel user in users)
            {
                Seller? seller = await this.dbContext
                    .Sellers
                    .FirstOrDefaultAsync(s => s.UserId.ToString() == user.Id);

                if (seller != null)
                {
                    user.Address = seller.Address;
                    user.PhoneNumber = seller.PhoneNumber;
                }
                else
                {
                    user.Address = string.Empty;
                    user.PhoneNumber = string.Empty;
                }
            }

            return users;
        }

        public async Task<string> GetFullNameAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return user.FirstName + " " + user.LastName;
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return String.Empty;
            }


            return user.FirstName + " " + user.LastName;
        }

        public async Task<bool> IsWatchInFavoritesAsync(string userId, string watchId)
        {
            var user = await dbContext.Users
                .Include(u => u.FavoriteWatches)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            return user?.FavoriteWatches.Any(fw => fw.Id.ToString() == watchId) ?? false;
        }

        public async Task<bool> RemoveFromFavoritesAsync(string userId, string watchId)
        {

            var user = await dbContext.Users
                .Include(u => u.FavoriteWatches)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user != null)
            {
                var watchToRemove = user.FavoriteWatches.FirstOrDefault(fw => fw.Id.ToString() == watchId);
                if (watchToRemove != null)
                {
                    user.FavoriteWatches.Remove(watchToRemove);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;


        }
    }
}
