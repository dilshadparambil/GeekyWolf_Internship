using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDTO> AddCustomer(AddCustomerDTO dto);
        Task<CustomerResponseDTO> UpdateCustomer(int id, UpdateCustomerDTO dto);
        Task<bool> DeleteCustomer(int id);
        Task<CustomerResponseDTO> GetCustomerById(int id);
        Task<List<CustomerResponseDTO>> GetAllCustomers();
    }
}
