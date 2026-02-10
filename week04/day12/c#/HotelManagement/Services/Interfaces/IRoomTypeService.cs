using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<RoomTypeResponseDTO> AddRoomType(AddRoomTypeDTO dto);
        Task<RoomTypeResponseDTO> UpdateRoomType(int id, UpdateRoomTypeDTO dto);
        Task<bool> DeleteRoomType(int id);
        Task<RoomTypeResponseDTO> GetRoomTypeById(int id);
        Task<List<RoomTypeResponseDTO>> GetAllRoomTypes();
    }
}
