using MediatR;
using Hotel.Management.Application.DTOs;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Domain.Entities;

namespace Hotel.Management.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeResponseDTO>
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponseDTO>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHotelRepository _hotelRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IHotelRepository HotelRepository)
        {
            _employeeRepository = EmployeeRepository;
            _hotelRepository = HotelRepository;
        }

        public async Task<EmployeeResponseDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null)
                return null;

            var hotel = await _hotelRepository.GetHotelByIdAsync(employee.HotelClassId);

            employee.Role = request.Role;

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return new EmployeeResponseDTO
            {
                Id = employee.Id,
                HotelName = hotel.Name,
                FullName = employee.FullName,
                Role = employee.Role,
                Email = employee.Email
            };
        }
    }
}