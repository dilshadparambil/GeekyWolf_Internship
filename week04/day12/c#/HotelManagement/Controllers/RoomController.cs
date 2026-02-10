using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(AddRoomDTO dto)
        {
            return Ok(await _roomService.AddRoom(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, UpdateRoomDTO dto)
        {
            return Ok(await _roomService.UpdateRoom(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            return Ok(await _roomService.DeleteRoom(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            return Ok(await _roomService.GetRoomById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await _roomService.GetAllRooms());
        }
    }
}
