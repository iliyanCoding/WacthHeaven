using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Seller;

namespace WatchHeaven.Web.ViewModels.Watch
{
    public class WatchDetailsViewModel : WatchAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Condition { get; set; } = null!;

        public SellerInfoOnWatchViewModel Seller { get; set; } = null!;
    }
}
