using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelDbContext _contextdb;

        public RoomTypeService(HotelDbContext contextdb)
        {
            _contextdb = contextdb;
        }

        public async Task<RoomTypeResponseDTO> AddRoomType(AddRoomTypeDTO dto)
        {
            var roomType = new RoomType
            {
                TypeName = dto.TypeName,
                Description = dto.Description,
                Capacity = dto.Capacity
            };

            _contextdb.RoomTypes.Add(roomType);
            await _contextdb.SaveChangesAsync();

            return new RoomTypeResponseDTO
            {
                Id = roomType.Id,
                TypeName = roomType.TypeName,
                Description = roomType.Description,
                Capacity = roomType.Capacity
            };
        }

        public async Task<RoomTypeResponseDTO> UpdateRoomType(int id, UpdateRoomTypeDTO dto)
        {
            var roomType = await _contextdb.RoomTypes.FindAsync(id);
            if (roomType == null) return null;

            roomType.TypeName = dto.TypeName ?? roomType.TypeName;
            roomType.Description = dto.Description ?? roomType.Description;
            roomType.Capacity = dto.Capacity ?? roomType.Capacity;

            await _contextdb.SaveChangesAsync();

            return new RoomTypeResponseDTO
            {
                Id = roomType.Id,
                TypeName = roomType.TypeName,
                Description = roomType.Description,
                Capacity = roomType.Capacity
            };
        }

        public async Task<bool> DeleteRoomType(int id)
        {
            var roomType = await _contextdb.RoomTypes.FindAsync(id);
            if (roomType == null) return false;

            _contextdb.RoomTypes.Remove(roomType);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<RoomTypeResponseDTO> GetRoomTypeById(int id)
        {
            var roomType = await _contextdb.RoomTypes.FindAsync(id);
            if (roomType == null) return null;

            return new RoomTypeResponseDTO
            {
                Id = roomType.Id,
                TypeName = roomType.TypeName,
                Description = roomType.Description,
                Capacity = roomType.Capacity
            };
        }

        public async Task<List<RoomTypeResponseDTO>> GetAllRoomTypes()
        {
            return await _contextdb.RoomTypes
                .Select(r => new RoomTypeResponseDTO
                {
                    Id = r.Id,
                    TypeName = r.TypeName,
                    Description = r.Description,
                    Capacity = r.Capacity
                }).ToListAsync();
        }
    }
}
