using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WatchHeaven.Common.EntityValidationConstants;

namespace WatchHeaven.Data.Model
{
    public class UserFavoriteWatch
    {

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Watch))]
        public Guid WatchId { get; set; }
        public Watch Watch { get; set; } = null!;

    }
}
