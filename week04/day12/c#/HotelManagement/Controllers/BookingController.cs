using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingDTO dto)
        {
            var booking = await _bookingService.AddBooking(dto);
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDTO dto)
        {
            var updated =await _bookingService.UpdateBooking(id, dto);
            if (updated == null)
                return NotFound($"Booking with ID {id} not found");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var deleted= await _bookingService.DeleteBooking(id);
            if(!deleted)
                return NotFound($"Booking with ID {id} not found");
            return Ok("deleeted successfully");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound($"Booking with ID {id} not found");
            return Ok(booking);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _bookingService.GetAllBookings());
        }
    }
}
