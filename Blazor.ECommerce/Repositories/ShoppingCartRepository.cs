using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor.ECommerce.Repositories
{
    public class ShoppingCartRepository(ApplicationDbContext _db): IShoppingCartRepository
    {
        public async Task<bool> UpdateCartAsync(Guid userId, int productId, int updateBy)
        {
            if ((userId) == Guid.Empty)
            {
                return false;
            }
            var cart = await _db.ShoppingCarts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = updateBy
                };

                _db.ShoppingCarts.Add(cart);
            }
            else
            {
                cart.Count += updateBy;
            }

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(Guid userId)
        {
            return await _db.ShoppingCarts
                .Where(c => c.UserId == userId)
                .Include(c => c.Product).AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ClearCartAsync(Guid? userId)
        {
            var shoppingCarts = await _db.ShoppingCarts.Where(c => c.UserId == userId).ToListAsync();
            _db.ShoppingCarts.RemoveRange(shoppingCarts);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
