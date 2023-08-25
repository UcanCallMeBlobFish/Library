namespace Books.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public List<Book_Genre> Book_Genre { get; set; }

    }
}
