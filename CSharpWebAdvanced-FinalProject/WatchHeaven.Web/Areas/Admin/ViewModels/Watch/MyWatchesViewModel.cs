using WatchHeaven.Web.ViewModels.Watch;

namespace WatchHeaven.Web.Areas.Admin.ViewModels.Watch
{
    public class MyWatchesViewModel
    {
        public MyWatchesViewModel()
        {
            this.AddedWatches = new HashSet<WatchAllViewModel>();
        }

        public IEnumerable<WatchAllViewModel> AddedWatches { get; set; }
    }
}
