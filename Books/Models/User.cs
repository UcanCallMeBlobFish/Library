using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
