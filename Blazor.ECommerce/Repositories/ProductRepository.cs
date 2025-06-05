using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor.ECommerce.Repositories 
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var entity = await _context.Products.FindAsync(Id);

            var relativeFileLocation = entity.ImageUrl.TrimStart('/').Replace("/", "\\");
            var fileLocation = Path.Combine(_webHostEnvironment.WebRootPath, relativeFileLocation);

            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }

            if (entity != null)
            {
                _context.Products.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p=>p.Category).ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id) ?? new Product();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var each = await _context.Products.FindAsync(entity.Id);

            if (each == null) return new Product();

            each.Name = entity.Name;
            each.Price = entity.Price;
            each.Description = entity.Description;
            each.SpecialTag = entity.SpecialTag;
            each.CategoryId = entity.CategoryId;
            each.ImageUrl = entity.ImageUrl;

            _context.Products.Update(each);

            await _context.SaveChangesAsync();

            return each;

        }
    }
}
