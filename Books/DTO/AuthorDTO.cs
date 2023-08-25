using System.ComponentModel.DataAnnotations;

namespace Books.DTO
{
    public class AuthorDTO
    {

        [StringLength(10, ErrorMessage ="Input length must be less than 10 character")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
