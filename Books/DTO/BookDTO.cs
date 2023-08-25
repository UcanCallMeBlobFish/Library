using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Books.DTO
{
    
    public class BookDTO
    {
        [StringLength(10, ErrorMessage ="Max Lenght is 10")]
        public string BookTitle { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
