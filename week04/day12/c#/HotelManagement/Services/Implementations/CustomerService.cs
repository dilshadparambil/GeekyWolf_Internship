using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelDbContext _contextdb;

        public CustomerService(HotelDbContext dbcontext)
        {
            _contextdb = dbcontext;
        }

        public async Task<CustomerResponseDTO> AddCustomer(AddCustomerDTO dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _contextdb.Customers.Add(customer);
            await _contextdb.SaveChangesAsync();

            return new CustomerResponseDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<CustomerResponseDTO> UpdateCustomer(int id, UpdateCustomerDTO dto)
        {
            var customer = await _contextdb.Customers.FindAsync(id);
            if (customer == null) return null;

            customer.FullName = dto.FullName ?? customer.FullName;
            customer.PhoneNumber = dto.PhoneNumber ?? customer.PhoneNumber;

            await _contextdb.SaveChangesAsync();

            return new CustomerResponseDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _contextdb.Customers.FindAsync(id);
            if (customer == null) return false;

            _contextdb.Customers.Remove(customer);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerResponseDTO> GetCustomerById(int id)
        {
            var customer = await _contextdb.Customers.FindAsync(id);
            if (customer == null) return null;

            return new CustomerResponseDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomers()
        {
            return await _contextdb.Customers
                .Select(c => new CustomerResponseDTO
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber
                })
                .ToListAsync();
        }
    }
}
