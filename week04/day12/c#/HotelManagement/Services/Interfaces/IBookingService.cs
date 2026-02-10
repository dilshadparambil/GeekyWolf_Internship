using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseDTO> AddBooking(AddBookingDTO dto);
        Task<BookingResponseDTO> UpdateBooking(int id,UpdateBookingDTO dto);
        Task<bool> DeleteBooking(int id);
        Task<BookingResponseDTO> GetBookingById(int id);
        Task<List<BookingResponseDTO>> GetAllBookings();
    }
}
