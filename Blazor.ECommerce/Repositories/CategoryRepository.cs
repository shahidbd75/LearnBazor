using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor.ECommerce.Repositories 
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {

        public async Task<Category> CreateAsync(Category entity)
        {
            await context.Categories.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(Category entity)
        {
            var each = await context.Categories.FindAsync(entity.Id);

            if (each != null)
            {
                context.Categories.Remove(each);
                return await context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await context.Categories.FindAsync(id) ?? new Category();
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            var each = await context.Categories.FindAsync(entity.Id);

            if (each != null)
            {
                each.Name = entity.Name;
                context.Categories.Update(each);

                await context.SaveChangesAsync();

                return each;
            }

            return new Category();
        }
    }
}
