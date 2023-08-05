using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Web.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
