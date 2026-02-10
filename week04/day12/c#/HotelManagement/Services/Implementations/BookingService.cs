using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly HotelDbContext _contextdb;

        public BookingService(HotelDbContext dbcontext)
        {
            _contextdb = dbcontext;
        }

        public async Task<BookingResponseDTO> AddBooking(AddBookingDTO dto)
        {
            var booking = new Booking
            {
                CheckInDate = dto.CheckInDate,
                CheckOutDate = dto.CheckOutDate,
                CustomerId = dto.CustomerId,
                RoomId = dto.RoomId,
                Status = BookingStatus.Pending
            };
            _contextdb.Bookings.Add(booking);
            await _contextdb.SaveChangesAsync();

            var result = await _contextdb.Bookings.Include(b => b.Customer).Include(b => b.Room).FirstOrDefaultAsync(b=>b.Id==booking.Id);

            return new BookingResponseDTO
            {
                Id = result.Id,
                CustomerName = result.Customer.FullName,
                RoomNumber = result.Room.RoomNumber,
                Status = result.Status

            };
        }
        public async Task<BookingResponseDTO> UpdateBooking(int id, UpdateBookingDTO dto)
        {
            var booking = await _contextdb.Bookings.Include(b => b.Customer).Include(b => b.Room).FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
                return null;
            booking.Status=dto.Status;
            await _contextdb.SaveChangesAsync();
            return new BookingResponseDTO
            {
                Id = booking.Id,
                CustomerName = booking.Customer.FullName,
                RoomNumber = booking.Room.RoomNumber,
                Status = booking.Status
            };
        }
        public async Task<bool> DeleteBooking(int id)
        {
            var booking = await _contextdb.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
                return false;
            _contextdb.Bookings.Remove(booking);
            await _contextdb.SaveChangesAsync();
            return true;
        }
        public async Task<BookingResponseDTO> GetBookingById(int id)
        {
            var booking= await _contextdb.Bookings.Include(b => b.Customer).Include(b => b.Room).FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null) return null;
            return new BookingResponseDTO
            {
                Id = booking.Id,
                CustomerName = booking.Customer.FullName,
                RoomNumber = booking.Room.RoomNumber,
                Status = booking.Status
            };

        }
        public async Task<List<BookingResponseDTO>> GetAllBookings()
        {
            return await _contextdb.Bookings.Include(b => b.Customer).Include(b => b.Room)
                .Select(booking=>new BookingResponseDTO
                {
                    Id = booking.Id,
                    CustomerName = booking.Customer.FullName,
                    RoomNumber = booking.Room.RoomNumber,
                    Status = booking.Status
                })
                .ToListAsync();

        }
    }
}
