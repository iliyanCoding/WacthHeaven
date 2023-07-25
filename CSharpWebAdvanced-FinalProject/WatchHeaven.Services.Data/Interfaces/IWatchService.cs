using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Services.Data.Models.Watch;
using WatchHeaven.Web.ViewModels.Home;
using WatchHeaven.Web.ViewModels.Watch;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface IWatchService
    {
        Task<IEnumerable<IndexViewModel>> MostExpensiveWatchesAsync();

        Task CreateAsync(WatchFormViewModel formViewModel, string sellerId);

        Task<AllWatchesFilteredAndPagedServiceModel> AllAsync(AllWatchesQueryModel queryModel);

        Task<IEnumerable<WatchAllViewModel>> AllBySellerIdAsync(string sellerId);

        Task<WatchDetailsViewModel> GetDetailsByIdAsync(string watchId);

        Task<bool> ExistsByIdAsync(string watchId);

        Task<WatchFormViewModel> GetWatchForEditByIdAsync(string watchId);

        Task<bool> IsSellerWithIdOwnerofWatchWithIdAsync(string sellerId, string watchId);

        Task EditWatchByIdAndFormModel(string watchId, WatchFormViewModel formModel);

    }
}
