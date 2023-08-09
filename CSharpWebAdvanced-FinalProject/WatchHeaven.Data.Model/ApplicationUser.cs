using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static WatchHeaven.Common.EntityValidationConstants.User;

namespace WatchHeaven.Data.Model
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.FavoriteWatches = new HashSet<Watch>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Watch> FavoriteWatches { get; set; }
    }
}
