
using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeResponseDTO> AddEmployee(AddEmployeeDTO dto);
        Task<EmployeeResponseDTO> UpdateEmployee(int id, UpdateEmployeeDTO dto);
        Task<bool> DeleteEmployee(int id);
        Task<EmployeeResponseDTO> GetEmployeeById(int id);
        Task<List<EmployeeResponseDTO>> GetAllEmployees();
    }
}
