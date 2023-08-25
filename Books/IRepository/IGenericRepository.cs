using System.Linq.Expressions;

namespace Books.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T obj);
        Task DeleteAsync(T obj);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> id, params Expression<Func<T, object>>[] includeProperties);
        Task UpdateAsync(T obj);
    }
}