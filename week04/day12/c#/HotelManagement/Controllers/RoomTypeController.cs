using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomType(AddRoomTypeDTO dto)
        {
            var result = await _roomTypeService.AddRoomType(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, UpdateRoomTypeDTO dto)
        {
            var result = await _roomTypeService.UpdateRoomType(id, dto);
            if (result == null) return NotFound("RoomType not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var deleted = await _roomTypeService.DeleteRoomType(id);
            if (!deleted) return NotFound("RoomType not found");

            return Ok("RoomType deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomType(int id)
        {
            var result = await _roomTypeService.GetRoomTypeById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            return Ok(await _roomTypeService.GetAllRoomTypes());
        }
    }
}
