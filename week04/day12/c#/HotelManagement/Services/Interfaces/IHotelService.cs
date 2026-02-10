using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;

namespace HotelMangement.Services.Interfaces
{
    public interface IHotelService
    {
        Task<HotelResponseDTO> AddHotel(AddHotelDTO dto);
        Task<HotelResponseDTO> UpdateHotel(int id, UpdateHotelDTO dto);
        Task<bool> DeleteHotel(int id);
        Task<HotelResponseDTO> GetHotelById(int id);
        Task<List<HotelResponseDTO>> GetAllHotels();
    }

}
