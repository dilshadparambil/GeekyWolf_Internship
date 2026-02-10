
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task<HotelClass> AddHotelAsync(HotelClass Hotel);
        Task UpdateHotelAsync(HotelClass Hotel);
        Task DeleteHotelAsync(HotelClass Hotel);
        Task<HotelClass> GetHotelByIdAsync(int id);
        Task<List<HotelClass>> GetAllHotelsAsync();
    }
}


