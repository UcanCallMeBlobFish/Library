using Books.Data;
using Books.IRepository;
using Books.Models;
using Microsoft.AspNetCore.Identity;

namespace Books.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

      
        public UnitOfWork(SignInManager<User> signInManager, UserManager<User> userManager, IAuthorRepository author, IBookRepository book, IGenreRepository genre, IReviewRepository review, AppDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            AuthorRepository = author;
            BookRepository = book;
            GenreRepository = genre;
            ReviewRepository = review;           
        }

        public  UserManager<User> _userManager { get; }
        public  SignInManager<User> _signInManager { get; }

        public IGenericRepository<Author> AuthorRepository { get; }
        public  IBookRepository BookRepository { get; }
        public IGenericRepository<Genre> GenreRepository { get; }
        public  IGenericRepository<Review> ReviewRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
