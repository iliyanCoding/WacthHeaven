using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Data.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.FavouriteWatches = new HashSet<Watch>();
        }
        public virtual ICollection<Watch> FavouriteWatches { get; set; }

    }
}
