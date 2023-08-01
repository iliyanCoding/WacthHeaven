using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Seller;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface ISellerService
    {
        Task<bool> SellerExistsByUserIdAsync(string userId);

        Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> SellerExistsByAddressAsync(string address);

        Task CreateSellerAsync(string userId, BecomeSellerFormModel model);

        Task<string?> GetSellerIdByUserIdAsync(string userId);

        Task<bool> HasWatchWithIdAsync(string userId, string watchId);
    }
}
