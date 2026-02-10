
using MediatR;
using Hotel.Management.Application.Queries;
using Hotel.Management.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Hotel.Management.Application.DTOs;

namespace HotelMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] AddHotelDTO dto)
        {
            var command = new CreateHotelCommand
            {
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                PhoneNumber = dto.PhoneNumber
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO dto)
        {
            var command = new UpdateHotelCommand
            {
                Id = id,
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                PhoneNumber = dto.PhoneNumber
            };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound($"Hotel with ID {id} not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var command= new DeleteHotelCommand { Id = id };
            var result= await _mediator.Send(command);

            if (!result)
                return NotFound($"Hotel with ID {id} not found");
            return Ok("Deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var query = new GetHotelByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"Hotel with ID {id} not found");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var query = new GetAllHotelsQuery(); 
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }



}