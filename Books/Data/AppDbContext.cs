using Books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Book_Genre> Book_Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Relationships

            modelBuilder.
                Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.
                Entity<Genre>()
                .HasMany(a => a.Book_Genre)
                .WithOne(a => a.Genre)
                .HasForeignKey(a => a.GenreId);

            modelBuilder.
                Entity<Book>()
                .HasMany(a => a.Book_Genre)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

            modelBuilder.
                Entity<Review>()
                .HasOne(a => a.Book)
                .WithMany(a => a.Reviews)
                .HasForeignKey(a => a.BookId);

            //Data Anotations

            modelBuilder
                .Entity<Author>()
                .Property(a => a.Name)
                .HasMaxLength(10);

            modelBuilder
                .Entity<Book>()
                .Property(a => a.BookTitle)
                .HasMaxLength(10);

            modelBuilder.Entity<Book_Genre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });


        }

    }
}
