using Books.Data;
using Books.IRepository;
using Books.Models;

namespace Books.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}
