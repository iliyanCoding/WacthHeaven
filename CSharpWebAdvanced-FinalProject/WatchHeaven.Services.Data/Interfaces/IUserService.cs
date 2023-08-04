using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameAsync(string email);
    }
}
