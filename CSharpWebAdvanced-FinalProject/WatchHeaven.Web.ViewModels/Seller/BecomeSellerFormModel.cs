using System.ComponentModel.DataAnnotations;
using static WatchHeaven.Common.EntityValidationConstants.Seller;

namespace WatchHeaven.Web.ViewModels.Seller
{
    public class BecomeSellerFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
