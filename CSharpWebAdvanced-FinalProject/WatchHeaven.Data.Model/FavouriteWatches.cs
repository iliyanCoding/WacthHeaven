using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Data.Model
{
    public class FavouriteWatches
    {
        public Guid UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid WatchId { get; set; }

        public Watch Watch { get; set; } = null!;
    }
}
