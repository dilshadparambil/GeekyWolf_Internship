using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Queries
{
    public class GetAllBookingsQuery : IRequest<List<BookingResponseDTO>>
    {
    }
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingResponseDTO>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingsQueryHandler(IBookingRepository BookingRepository)
        {
            _bookingRepository = BookingRepository;
        }

        public async Task<List<BookingResponseDTO>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        { 
            var Bookings = await _bookingRepository.GetAllBookingsAsync();
            var dtoList = Bookings.Select(b => new BookingResponseDTO
            {
                Id = b.Id,
                CustomerName = b.Customer.FullName,
                RoomNumber = b.Room.RoomNumber,
                Status = b.Status
            })
            .ToList();
            return dtoList;
        }
    }
}