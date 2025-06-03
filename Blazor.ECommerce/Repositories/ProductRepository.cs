using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor.ECommerce.Repositories 
{
    public class ProductRepository(ApplicationDbContext context) : IProductRepository
    {

        public async Task<Product> CreateAsync(Product entity)
        {
            await context.Products.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var entity = await context.Products.FindAsync(Id);

            if (entity != null)
            {
                context.Products.Remove(entity);
                return await context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products.FindAsync(id) ?? new Product();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var each = await context.Products.FindAsync(entity.Id);

            if (each == null) return new Product();

            each.Name = entity.Name;
            each.Price = entity.Price;
            each.Description = entity.Description;
            each.SpecialTag = entity.SpecialTag;
            each.CategoryId = entity.CategoryId;
            each.ImageUrl = entity.ImageUrl;

            context.Products.Update(each);

            await context.SaveChangesAsync();

            return each;

        }
    }
}
