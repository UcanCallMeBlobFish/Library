using AutoMapper;
using Books.Data;
using Books.DTO;
using Books.IRepository;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            var query = await _unitOfWork.BookRepository.GetAllAsync();
            var booksdto = query.Select(_mapper.Map<Book, BookDTO>).ToList();
            return Ok(booksdto);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Book(int Id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.BookRepository.GetByIdAsync(a => a.BookId == Id);
            var booksdto = _mapper.Map<Book, BookDTO>(query);
            return Ok(booksdto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var temp = _mapper.Map<BookDTO, Book>(book);
            await _unitOfWork.BookRepository.CreateAsync(temp);
            await _unitOfWork.SaveChangesAsync();
            return Ok(temp);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.BookRepository.GetByIdAsync(a => a.BookId == Id);
            await _unitOfWork.BookRepository.DeleteAsync(query);
            await _unitOfWork.SaveChangesAsync();   
            return Ok(query);

        }

    }
}
