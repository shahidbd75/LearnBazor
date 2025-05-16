namespace Blazor.ECommerce.Repositories.IRepositories
{
    public interface IBaseRepository<T, TId> 
    {
        T Create(T entity);
        T Update(T entity);

        bool Delete(T entity);
        T Get(TId id);
        IEnumerable<T> GetAll();

    }
}
