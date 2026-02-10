
using MediatR;
using Hotel.Management.Application.Queries;
using Hotel.Management.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Entities;

namespace HotelMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] AddRoomDTO dto)
        {
            var command = new CreateRoomCommand
            {
                RoomNumber = dto.RoomNumber,
                HotelClassId = dto.HotelClassId,
                RoomTypeId = dto.RoomTypeId,
                PricePerNight = dto.PricePerNight,
                Status = dto.Status
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomDTO dto)
        {
            var command = new UpdateRoomCommand
            {
                Id = id,
                RoomNumber = dto.RoomNumber,
                PricePerNight = dto.PricePerNight,
                Status = RoomStatus.Available
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound($"Room with ID {id} not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var command = new DeleteRoomCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"Room with ID {id} not found");
            return Ok("Deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var query = new GetRoomByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"Room with ID {id} not found");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var query = new GetAllRoomsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }



}