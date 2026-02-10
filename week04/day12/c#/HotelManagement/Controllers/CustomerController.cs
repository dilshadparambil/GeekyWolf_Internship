using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDTO dto)
        {
            var result = await _customerService.AddCustomer(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerDTO dto)
        {
            var result = await _customerService.UpdateCustomer(id, dto);
            if (result == null) return NotFound("Customer not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerService.DeleteCustomer(id);
            if (!deleted) return NotFound("Customer not found");
            return Ok("Deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomers();
            return Ok(result);
        }
    }
}
