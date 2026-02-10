namespace Hotel.Management.Application.DTOs
{
    public class AddEmployeeDTO
    {
        public int HotelClassId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }

    public class UpdateEmployeeDTO
    {
        public string Role { get; set; }
    }

    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }

}
