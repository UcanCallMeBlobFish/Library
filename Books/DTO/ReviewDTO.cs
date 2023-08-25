using System.ComponentModel.DataAnnotations;

namespace Books.DTO
{
    public class ReviewDTO
    {
        [StringLength(100, MinimumLength = 10)]
        public string ReviewText { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
