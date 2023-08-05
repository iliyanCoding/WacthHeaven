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
    }
}
