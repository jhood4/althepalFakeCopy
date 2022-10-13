﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fake.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price")]
        public double Price { get; set; }       

        [ValidateNever]
        public string ImgURL { get; set; }

        [Display(Name ="Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        public ICollection<ProductMenu>? ProductMenus { get; set; }
    }
}
