using Books.Models;
using Microsoft.AspNetCore.Identity;

namespace Books.IRepository
{
    public interface IUnitOfWork
    {
        SignInManager<User> _signInManager { get; }

        UserManager<User> _userManager { get; }
        IGenericRepository<Author> AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Review> ReviewRepository { get; }

        Task SaveChangesAsync();



    }
}
