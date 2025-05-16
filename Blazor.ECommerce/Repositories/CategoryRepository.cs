using Blazor.ECommerce.Data;
using Blazor.ECommerce.Repositories.IRepositories;

namespace Blazor.ECommerce.Repositories 
{
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        public Category Create(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(Category entity)
        {
            var each = context.Categories.Find(entity.Id);

            if(each != null)
            {
                context.Categories.Remove(each);
                return context.SaveChanges() > 0;
            }

            return false;
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id) ?? new Category();
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category Update(Category entity)
        {
            var each = context.Categories.Find(entity.Id);

            if (each != null)
            {
                each.Name = entity.Name;
                context.Categories.Update(each);

                context.SaveChanges();

                return each;
            }

            return new Category();
        }
    }
}
