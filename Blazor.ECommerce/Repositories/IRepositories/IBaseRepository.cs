namespace Blazor.ECommerce.Repositories.IRepositories
{
    public interface IBaseRepository<T, TId> 
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(TId id);
        Task<T> GetAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
