using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Commands
{
    public class UpdateBookingCommand : IRequest<BookingResponseDTO>
    {
        public int Id { get; set; }
        public BookingStatus Status { get; set; }
    }
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BookingResponseDTO>
    {
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingCommandHandler(IBookingRepository BookingRepository)
        {
            _bookingRepository = BookingRepository;
        }

        public async Task<BookingResponseDTO> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
                return null;

            booking.Status = request.Status;

            await _bookingRepository.UpdateBookingAsync(booking);
            return new BookingResponseDTO
            {
                Id = booking.Id,
                CustomerName = booking.Customer.FullName,
                RoomNumber = booking.Room.RoomNumber,
                Status = booking.Status
            };
        }
    }
}