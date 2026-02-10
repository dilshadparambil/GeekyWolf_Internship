
using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewDTO dto)
        {
            return Ok(await _reviewService.AddReview(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, UpdateReviewDTO dto)
        {
            var result = await _reviewService.UpdateReview(id,dto);
            if (result == null) return NotFound("Review not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var removed = await _reviewService.DeleteReview(id);
            if (!removed) return NotFound("Review not found");

            return Ok("Review deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var result = await _reviewService.GetReviewById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            return Ok(await _reviewService.GetAllReviews());
        }
    }
}
