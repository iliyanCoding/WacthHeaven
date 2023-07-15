using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Home;

namespace WatchHeaven.Services.Data.Interfaces
{
    public interface IWatchService
    {
        Task<IndexViewModel> MostExpensiveWatchAsync();
    }
}
