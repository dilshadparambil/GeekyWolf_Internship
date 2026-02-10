
using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] AddHotelDTO dto)
        {
            var hotel = await _hotelService.AddHotel(dto);
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO dto)
        {
            var result = await _hotelService.UpdateHotel(id, dto);
            if (result == null)
                return NotFound($"Hotel with ID {id} not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var deleted = await _hotelService.DeleteHotel(id);
            if (!deleted)
                return NotFound($"Hotel with ID {id} not found");

            return Ok("Deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel == null)
                return NotFound($"Hotel with ID {id} not found");

            return Ok(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            return Ok(await _hotelService.GetAllHotels());
        }
    }



}