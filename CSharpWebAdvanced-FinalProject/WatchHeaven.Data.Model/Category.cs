using System.ComponentModel.DataAnnotations;
using static WatchHeaven.Common.EntityValidationConstants.Category;

namespace WatchHeaven.Data.Model
{
    public class Category
    {
        public Category()
        {
            this.Watches = new HashSet<Watch>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Watch> Watches { get; set; }
    }
}