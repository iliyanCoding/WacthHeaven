using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.User;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameAsync(string email);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
