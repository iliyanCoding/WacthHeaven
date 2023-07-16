using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Category;
using WatchHeaven.Web.ViewModels.Condition;

namespace WatchHeaven.Web.ViewModels.Watch
{
    public class WatchFormViewModel
    {
        public WatchFormViewModel()
        {
            this.Categories = new HashSet<WatchSelectCategoryFormModel>();   
            this.Conditions = new HashSet<WatchSelectConditionFormModel>();
        }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<WatchSelectCategoryFormModel> Categories { get; set; }

        public int ConditionId { get; set; }

        public IEnumerable<WatchSelectConditionFormModel> Conditions { get; set; }
    }
}
