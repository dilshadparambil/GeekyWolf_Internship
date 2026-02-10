namespace Hotel.Management.Application.DTOs
{
    public class AddHotelDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdateHotelDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class HotelResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

}
