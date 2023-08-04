using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Data.Model;
using WatchHeaven.Services.Data.Interfaces;
using WatchHeaven.Web.Data;

namespace WatchHeaven.Services.Data
{
    public class UserService : IUserService
    {
        private readonly WatchHeavenDbContext dbContext;

        public UserService(WatchHeavenDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
