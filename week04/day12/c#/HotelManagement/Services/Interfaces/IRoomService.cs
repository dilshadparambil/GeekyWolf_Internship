using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IRoomService
    {
        Task<RoomResponseDTO> AddRoom(AddRoomDTO dto);
        Task<RoomResponseDTO> UpdateRoom(int id, UpdateRoomDTO dto);
        Task<bool> DeleteRoom(int id);
        Task<RoomResponseDTO> GetRoomById(int id);
        Task<List<RoomResponseDTO>> GetAllRooms();
    }
}