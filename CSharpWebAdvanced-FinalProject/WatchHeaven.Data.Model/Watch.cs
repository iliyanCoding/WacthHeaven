﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WatchHeaven.Common.EntityValidationConstants.Watch;

namespace WatchHeaven.Data.Model
{
    public class Watch
    {
        public Watch()
        {
            this.Id = Guid.NewGuid();

        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public DateTime AddedOn { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }

        public Condition Condition { get; set; } = null!;

        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }

        public Seller Seller { get; set; } = null!;

        public ICollection<ApplicationUser> UsersWhoFavorited { get; set; } = new HashSet<ApplicationUser>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
