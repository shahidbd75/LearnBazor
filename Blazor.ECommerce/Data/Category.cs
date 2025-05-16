﻿using System.ComponentModel.DataAnnotations;

namespace Blazor.ECommerce.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
