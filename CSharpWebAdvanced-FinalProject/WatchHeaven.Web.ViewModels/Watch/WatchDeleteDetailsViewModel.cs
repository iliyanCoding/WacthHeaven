using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Web.ViewModels.Watch
{
    public class WatchDeleteDetailsViewModel
    {
        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = null!;
    }
}
