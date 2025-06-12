using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.ECommerce.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Range(0.01, 10000)]
        public double Price { get; set; }
        public string? Description { get; set; }

        public string? SpecialTag { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string? ImageUrl { get; set; }
    }
}
