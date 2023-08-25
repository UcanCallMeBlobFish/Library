using AutoMapper;
using Books.DTO;
using Books.IRepository;
using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenreController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Genres()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.GenreRepository.GetAllAsync();
            var genreDto = query.Select(_mapper.Map<Genre, GenreDTO>).ToList();
            return Ok(genreDto);
        }

        [HttpGet]
        [Route("{Id:int}")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Genre(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.GenreRepository.GetByIdAsync(a => a.GenreId == Id);
            var genreDto = _mapper.Map<Genre, GenreDTO>(query);
            return Ok(genreDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromBody] GenreDTO obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var genre = _mapper.Map<GenreDTO,Genre>(obj);
            await _unitOfWork.GenreRepository.CreateAsync(genre);
            await _unitOfWork.SaveChangesAsync();
            return Ok(genre);


        }

        [HttpDelete]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int Id)
        {
            var query = await _unitOfWork.GenreRepository.GetByIdAsync(a => a.GenreId == Id);
            await _unitOfWork.GenreRepository.DeleteAsync(query);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Deleted");
        }


    }
}
