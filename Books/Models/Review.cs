using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string ReviewText { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        //Nav
        [JsonIgnore]
        public Book Book { get; set; }
        public int BookId { get; set; }


    }
}
