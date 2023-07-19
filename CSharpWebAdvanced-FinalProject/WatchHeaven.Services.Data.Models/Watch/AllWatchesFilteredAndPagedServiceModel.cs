using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Watch;

namespace WatchHeaven.Services.Data.Models.Watch
{
    public class AllWatchesFilteredAndPagedServiceModel
    {
        public AllWatchesFilteredAndPagedServiceModel()
        {
            this.Watches = new HashSet<WatchAllViewModel>();    
        }

        public int TotalWatchesCount { get; set; }

        public IEnumerable<WatchAllViewModel> Watches { get; set; }
    }
}
