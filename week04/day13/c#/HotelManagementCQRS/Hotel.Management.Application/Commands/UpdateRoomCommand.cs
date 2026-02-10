using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Commands
{
    public class UpdateRoomCommand : IRequest<RoomResponseDTO>
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public RoomStatus Status { get; set; }
        public decimal PricePerNight { get; set; }
    }
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomResponseDTO>
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateRoomCommandHandler(IRoomRepository RoomRepository)
        { 
            _roomRepository = RoomRepository;
        }

        public async Task<RoomResponseDTO> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
                return null;

            room.RoomNumber = request.RoomNumber ?? room.RoomNumber;
            room.Status = request.Status;
            room.PricePerNight = request.PricePerNight;

            await _roomRepository.UpdateRoomAsync(room);
            return new RoomResponseDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                HotelName = room.HotelClass.Name,
                RoomType = room.RoomType.TypeName,
                PricePerNight = room.PricePerNight,
                Status = room.Status
            };
        }
    }
}