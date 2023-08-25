using System.Text.Json.Serialization;

namespace Books.Models
{
    public class Author  // 1:m with books
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        //nav
        public int BookId { get; set; }

        public List<Book> Books { get; set; }
    }
}
