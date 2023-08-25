using AutoMapper;
using Books.DTO;
using Books.IRepository;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            var qeury = await _unitOfWork.AuthorRepository.GetAllAsync();
            var authorsdto = qeury.Select(_mapper.Map<Author, AuthorDTO>);
            return Ok(authorsdto);
        }

        [HttpGet]
        [Route("{Id:int}")]   
        public async Task<IActionResult> Author(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);  
            var query = await _unitOfWork.AuthorRepository.GetByIdAsync(x => x.AuthorId == Id);
            var authordto = _mapper.Map<Author,AuthorDTO>(query);
            return Ok(authordto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromBody] AuthorDTO authordto)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            var auth = _mapper.Map<Author>(authordto);
            await _unitOfWork.AuthorRepository.CreateAsync(auth);
            await _unitOfWork.SaveChangesAsync();
            return Ok(auth);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit([FromBody] Author author)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _unitOfWork.AuthorRepository.UpdateAsync(author);
            await _unitOfWork.SaveChangesAsync();
            return Ok(author);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var query = await _unitOfWork.AuthorRepository.GetByIdAsync(x => x.AuthorId == Id);
            await _unitOfWork.AuthorRepository.DeleteAsync(query);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Deleted");
        }

    }
}
