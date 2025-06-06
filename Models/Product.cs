﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1000, 1000000, ErrorMessage = "Price must be between 1000 and 1000000")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price For 50+")]
        [Range(1000, 1000000, ErrorMessage = "Price must be between 1000 and 1000000")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "PriceFor 100+")]
        [Range(1000, 1000000, ErrorMessage = "Price must be between 1000 and 1000000")]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Catergory Catergory { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
