using HotelMangement.Models.Entities;

namespace HotelMangement.Models.DTOs
{
    public class AddRoomDTO
    {
        public string RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomStatus Status { get; set; }
        public decimal PricePerNight { get; set; }
    }

    public class UpdateRoomDTO
    {
        public string RoomNumber { get; set; }
        public RoomStatus Status { get; set; }
        public decimal PricePerNight { get; set; }
    }

    public class RoomResponseDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public RoomStatus Status { get; set; }
        public string HotelName { get; set; }
        public string RoomType { get; set; }
    }

}
