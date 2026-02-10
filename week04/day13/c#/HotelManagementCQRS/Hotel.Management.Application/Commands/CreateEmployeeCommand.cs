using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponseDTO>
    {
        public int HotelClassId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponseDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHotelRepository _hotelRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IHotelRepository HotelRepository)
        {
            _employeeRepository = EmployeeRepository;
            _hotelRepository = HotelRepository;
        }

        public async Task<EmployeeResponseDTO> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                HotelClassId = request.HotelClassId,
                FullName = request.FullName,
                Role = request.Role,
                Email = request.Email
            };

            var result = await _employeeRepository.AddEmployeeAsync(employee);
            var hotel = await _hotelRepository.GetHotelByIdAsync(result.HotelClassId);

            return new EmployeeResponseDTO
            {
                Id = result.Id,
                HotelName = hotel.Name,
                FullName = result.FullName,
                Role = result.Role,
                Email = result.Email
            };
        }
    }
}