using AutoMapper;
using Books.Models;

namespace Books.DTO
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();


        }
    }
}
