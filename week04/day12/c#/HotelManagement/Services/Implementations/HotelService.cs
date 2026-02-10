using System;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using HotelMangement.Data;
using Microsoft.EntityFrameworkCore;
using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<HotelResponseDTO> AddHotel(AddHotelDTO dto)
        {
            var hotel = new Hotel
            {
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return new HotelResponseDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City
            };
        }

        public async Task<HotelResponseDTO> UpdateHotel(int id, UpdateHotelDTO dto)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
                return null;

            hotel.Name = dto.Name ?? hotel.Name;
            hotel.Address = dto.Address ?? hotel.Address;
            hotel.City = dto.City ?? hotel.City;
            hotel.Country = dto.Country ?? hotel.Country;
            hotel.PhoneNumber = dto.PhoneNumber ?? hotel.PhoneNumber;

            await _context.SaveChangesAsync();

            return new HotelResponseDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City
            };
        }

        public async Task<bool> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
                return false;

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<HotelResponseDTO> GetHotelById(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (hotel == null)
                return null;

            return new HotelResponseDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City
            };
        }

        public async Task<List<HotelResponseDTO>> GetAllHotels()
        {
            return await _context.Hotels
                .Select(h => new HotelResponseDTO
                {
                    Id = h.Id,
                    Name = h.Name,
                    City = h.City
                })
                .ToListAsync();
        }
    }


}

