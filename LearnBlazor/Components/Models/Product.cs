using System.ComponentModel.DataAnnotations;

namespace LearnBlazor.Components.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(1,1000)]
        public decimal Price { get; set; }

        public Boolean IsAvailable { get; set; }

        public IEnumerable<ProductVarient> ProductVarients { get; set; }

        public Category Catergory { get; set; }

        public DateOnly OfferEnd { get; set; }
    }

    public enum Category
    {
        Electronics,
        Clothing,
        Food,
        Toys,
        Books
    }
}
