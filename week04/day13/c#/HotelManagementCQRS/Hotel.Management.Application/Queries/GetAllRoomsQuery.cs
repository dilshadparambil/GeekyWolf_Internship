using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Queries
{
    public class GetAllRoomsQuery : IRequest<List<RoomResponseDTO>>
    {
    }
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<RoomResponseDTO>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler(IRoomRepository RoomRepository)
        {
            _roomRepository = RoomRepository;
        }

        public async Task<List<RoomResponseDTO>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var Rooms = await _roomRepository.GetAllRoomsAsync();
            var dtoList = Rooms.Select(r => new RoomResponseDTO
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                HotelName = r.HotelClass.Name,
                RoomType = r.RoomType.TypeName,
                PricePerNight = r.PricePerNight,
                Status = r.Status
            })
            .ToList();
            return dtoList;
        }
    }
}