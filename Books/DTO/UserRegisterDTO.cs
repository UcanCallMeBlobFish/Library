using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Books.DTO
{
    public class UserRegisterDTO
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
