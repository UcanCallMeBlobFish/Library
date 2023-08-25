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
    public class ReviewController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Reviews()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.ReviewRepository.GetAllAsync();
            var reviewDto = query.Select(_mapper.Map<Review, ReviewDTO>).ToList();
            return Ok(reviewDto);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Review(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var query = await _unitOfWork.ReviewRepository.GetByIdAsync(a => a.ReviewId == Id);
            var reviewDto = _mapper.Map<Review, ReviewDTO>(query);
            return Ok(reviewDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromBody] ReviewDTO obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var review = _mapper.Map<ReviewDTO, Review>(obj);
            await _unitOfWork.ReviewRepository.CreateAsync(review);
            await _unitOfWork.SaveChangesAsync();
            return Ok(review);


        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var query = await _unitOfWork.ReviewRepository.GetByIdAsync(a => a.ReviewId == Id);
            await _unitOfWork.ReviewRepository.DeleteAsync(query);
            await _unitOfWork.SaveChangesAsync();
            return Ok("Deleted");
        }



    }
}
