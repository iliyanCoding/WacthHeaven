using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
