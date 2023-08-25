using AutoMapper;
using Books.Data;
using Books.DTO;
using Books.IRepository;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Books.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper  _mapper;
        public BookRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(book => book.Author)
                .Include(book => book.Reviews)
                .Include(book => book.Book_Genre)
                .ThenInclude(book => book.Genre)
                .ToListAsync();

            // Use AutoMapper to map List<Book> to List<BookDTO>
            var bookDTOs = _mapper.Map<List<BookDTO>>(books);

            return bookDTOs;
        }





    }
}
