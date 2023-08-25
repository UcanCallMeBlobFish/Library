using Books.Data;
using Books.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return await query.AsNoTracking().FirstAsync(id);
        }

        public async Task CreateAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public async Task DeleteAsync(T obj)
        {
            await Task.FromResult(_context.Remove(obj));
        }

        public async Task UpdateAsync(T obj)
        {
            await Task.FromResult(_context.Update(obj));
        }
    }
}
