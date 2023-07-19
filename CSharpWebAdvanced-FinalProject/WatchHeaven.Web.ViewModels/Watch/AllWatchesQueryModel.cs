using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Watch.Enums;
using static WatchHeaven.Common.GeneralApplicationConstants;

namespace WatchHeaven.Web.ViewModels.Watch
{
    public class AllWatchesQueryModel
    {
        public AllWatchesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.WatchesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Conditions = new HashSet<string>();
            this.Watches = new HashSet<WatchAllViewModel>();
        }

        public string? Category { get; set; }

        public string? Condition { get; set; }

        [Display(Name = "Search")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort By")]
        public WatchSorting WatchSorting { get; set; }

        public int CurrentPage { get; set; }

        public int WatchesPerPage { get; set; }

        public int TotalWatches { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Conditions { get; set; }

        public IEnumerable<WatchAllViewModel> Watches { get; set; }
    }
}
