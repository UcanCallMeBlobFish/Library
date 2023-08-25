namespace Books.Models
{
    public class Book_Genre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Book Book { get; set; }

    }
}
