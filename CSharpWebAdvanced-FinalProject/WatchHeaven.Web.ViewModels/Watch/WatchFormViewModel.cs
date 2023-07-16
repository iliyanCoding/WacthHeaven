using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchHeaven.Web.ViewModels.Category;
using WatchHeaven.Web.ViewModels.Condition;
using static WatchHeaven.Common.EntityValidationConstants.Watch;

namespace WatchHeaven.Web.ViewModels.Watch
{
    public class WatchFormViewModel
    {
        public WatchFormViewModel()
        {
            this.Categories = new HashSet<WatchSelectCategoryFormModel>();   
            this.Conditions = new HashSet<WatchSelectConditionFormModel>();
        }

        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<WatchSelectCategoryFormModel> Categories { get; set; }

        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public IEnumerable<WatchSelectConditionFormModel> Conditions { get; set; }
    }
}
