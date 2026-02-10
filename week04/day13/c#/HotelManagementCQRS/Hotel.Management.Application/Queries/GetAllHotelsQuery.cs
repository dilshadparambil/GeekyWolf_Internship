using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;

namespace Hotel.Management.Application.Queries
{
    public class GetAllHotelsQuery : IRequest<List<HotelResponseDTO>>
    {
    }
    public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, List<HotelResponseDTO>>
    {
        private readonly IHotelRepository _hotelRepository;

        public GetAllHotelsQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<HotelResponseDTO>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();
            var dtoList = hotels.Select(h => new HotelResponseDTO
            {
                Id = h.Id,
                Name = h.Name,
                City = h.City
            })
            .ToList();
            return dtoList;
        }
    }
}