using System.Text.Json.Serialization;

namespace Books.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublicationDate { get; set; }

        //NavProp
        [JsonIgnore]
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public List<Review> Reviews { get; set; }
        public List<Book_Genre> Book_Genre { get; set; }

    }
}
