using Books.Models;

namespace Books.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                if (!context.Authors.Any())
                {
                    var author1 = new Author { Name = "Author 1", BirthDate = new DateTime(1990, 1, 1) };
                    var author2 = new Author { Name = "Author 2", BirthDate = new DateTime(1985, 5, 10) };
                    context.Authors.AddRange(author1, author2);
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    var book1 = new Book { BookTitle = "Book 1", PublicationDate = new DateTime(2020, 3, 15), AuthorId = 1 };
                    var book2 = new Book { BookTitle = "Book 2", PublicationDate = new DateTime(2018, 7, 20), AuthorId = 2 };
                    context.Books.AddRange(book1, book2);
                    context.SaveChanges();
                }

                if (!context.Genres.Any())
                {
                    var genre1 = new Genre { Name = "Fantasy" };
                    var genre2 = new Genre { Name = "Science Fiction" };
                    context.Genres.AddRange(genre1, genre2);
                    context.SaveChanges();
                }

                if (!context.Book_Genres.Any())
                {
                    var bookGenre1 = new Book_Genre { BookId = 1, GenreId = 1 };
                    var bookGenre2 = new Book_Genre { BookId = 2, GenreId = 2 };
                    context.Book_Genres.AddRange(bookGenre1, bookGenre2);
                    context.SaveChanges();
                }

                if (!context.Reviews.Any())
                {
                    var review1 = new Review { ReviewText = "Great book!", Rating = 5, BookId = 1 };
                    var review2 = new Review { ReviewText = "Interesting read.", Rating = 4, BookId = 2 };
                    context.Reviews.AddRange(review1, review2);
                    context.SaveChanges();
                }


            }
        }
    }
}
