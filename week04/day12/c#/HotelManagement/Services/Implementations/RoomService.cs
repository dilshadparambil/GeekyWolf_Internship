using HotelMangement.Data;
using HotelMangement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using HotelMangement.Models.DTOs;
using HotelMangement.Services.Interfaces;

namespace HotelMangement.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly HotelDbContext _context;

        public RoomService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<RoomResponseDTO> AddRoom(AddRoomDTO dto)
        {
            var hotel = await _context.Hotels.FindAsync(dto.HotelId);
            var roomType = await _context.RoomTypes.FindAsync(dto.RoomTypeId);

            if (hotel == null)
                throw new Exception($"Hotel with ID {dto.HotelId} does not exist.");

            if (roomType == null)
                throw new Exception($"RoomType with ID {dto.RoomTypeId} does not exist.");

            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                HotelId = dto.HotelId,
                RoomTypeId = dto.RoomTypeId,
                PricePerNight = dto.PricePerNight,
                Status = RoomStatus.Available
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                HotelName = hotel.Name,
                RoomType = roomType.TypeName,
                PricePerNight = room.PricePerNight,
                Status = room.Status
            };
        }

        public async Task<RoomResponseDTO> UpdateRoom(int id, UpdateRoomDTO dto)
        {
            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
                throw new Exception($"Room with ID {id} not found.");

            room.Status = dto.Status;
            room.PricePerNight = dto.PricePerNight;

            await _context.SaveChangesAsync();

            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                HotelName = room.Hotel.Name,
                RoomType = room.RoomType.TypeName,
                PricePerNight = room.PricePerNight,
                Status = room.Status
            };
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<RoomResponseDTO> GetRoomById(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
                throw new Exception($"Room with ID {id} not found.");

            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                HotelName = room.Hotel.Name,
                RoomType = room.RoomType.TypeName,
                PricePerNight = room.PricePerNight,
                Status = room.Status
            };
        }

        public async Task<List<RoomResponseDTO>> GetAllRooms()
        {
            return await _context.Rooms
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .Select(room => new RoomResponseDTO
                {
                    Id = room.Id,
                    RoomNumber = room.RoomNumber,
                    HotelName = room.Hotel.Name,
                    RoomType = room.RoomType.TypeName,
                    PricePerNight = room.PricePerNight,
                    Status = room.Status
                })
                .ToListAsync();
        }
    }
}
