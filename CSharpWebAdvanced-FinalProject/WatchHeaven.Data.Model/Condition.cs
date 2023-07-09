using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WatchHeaven.Common.EntityValidationConstants.Condition;
namespace WatchHeaven.Data.Model
{
    public class Condition
    {
        public Condition()
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
