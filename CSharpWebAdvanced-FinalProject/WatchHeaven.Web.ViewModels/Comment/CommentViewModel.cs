using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Web.ViewModels.Comment
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime CommentedOn { get; set; }
        public Guid UserId { get; set; }
        public Guid WatchId { get; set; }

    }
}
