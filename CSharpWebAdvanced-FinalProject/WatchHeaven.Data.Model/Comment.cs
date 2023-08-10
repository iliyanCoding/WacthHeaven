using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WatchHeaven.Common.EntityValidationConstants.Comment;

namespace WatchHeaven.Data.Model
{
    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Watch))]
        public Guid WatchId { get; set; }
        public Watch Watch { get; set; } = null!;

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        public DateTime CommentedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
