using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.ECommerce.Data
{
    public class ShoppingCart
    {
        public Guid CartId { get; set; } = Guid.NewGuid();

        public required Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public required int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public required int Count { get; set; }
    }
}
