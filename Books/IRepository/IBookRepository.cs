using Books.Data;
using Books.DTO;
using Books.Models;

namespace Books.IRepository
{
    public interface IBookRepository:IGenericRepository<Book>
    {

        Task<List<BookDTO>> GetAllBooksAsync();

    }
}
