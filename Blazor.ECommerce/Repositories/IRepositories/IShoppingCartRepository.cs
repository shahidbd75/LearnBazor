using Blazor.ECommerce.Data;

namespace Blazor.ECommerce.Repositories.IRepositories
{
    public interface IShoppingCartRepository
    {
        Task<bool> UpdateCartAsync(Guid userId, int productId, int updateBy);
        Task<IEnumerable<ShoppingCart>> GetAllAsync(Guid userId);
        Task<bool> ClearCartAsync(Guid? userId);
    }
}
