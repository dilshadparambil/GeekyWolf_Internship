
using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HotelDbContext _contextdb;

        public EmployeeService(HotelDbContext contextdb)
        {
            _contextdb = contextdb;
        }

        public async Task<EmployeeResponseDTO> AddEmployee(AddEmployeeDTO dto)
        {
            var employee = new Employee
            {
                HotelId = dto.HotelId,
                FullName = dto.FullName,
                Role = dto.Role,
                Email = dto.Email
            };

            _contextdb.Employees.Add(employee);
            await _contextdb.SaveChangesAsync();

            var hotel = await _contextdb.Hotels.FindAsync(dto.HotelId);

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                HotelName = hotel?.Name ?? "Unknown",
                FullName = employee.FullName,
                Role = employee.Role,
                Email = employee.Email
            };
        }

        public async Task<EmployeeResponseDTO> UpdateEmployee(int id, UpdateEmployeeDTO dto)
        {
            var employee = await _contextdb.Employees.FindAsync(id);
            if (employee == null) return null;

            employee.Role = dto.Role ?? employee.Role;

            await _contextdb.SaveChangesAsync();

            var hotel = await _contextdb.Hotels.FindAsync(employee.HotelId);

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                HotelName = hotel?.Name ?? "Unknown",
                FullName = employee.FullName,
                Role = employee.Role,
                Email = employee.Email
            };
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _contextdb.Employees.FindAsync(id);
            if (employee == null) return false;

            _contextdb.Employees.Remove(employee);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
            var employee = await _contextdb.Employees.Include(e => e.Hotel).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return null;

            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                HotelName = employee.Hotel?.Name,
                FullName = employee.FullName,
                Role = employee.Role,
                Email = employee.Email
            };
        }

        public async Task<List<EmployeeResponseDTO>> GetAllEmployees()
        {
            return await _contextdb.Employees
                .Include(e => e.Hotel)
                .Select(e => new EmployeeResponseDTO
                {
                    Id = e.Id,
                    HotelName = e.Hotel.Name,
                    FullName = e.FullName,
                    Role = e.Role,
                    Email = e.Email
                })
                .ToListAsync();
        }
    }
}
