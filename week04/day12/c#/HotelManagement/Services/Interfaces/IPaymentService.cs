
using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDTO> AddPayment(AddPaymentDTO dto);
        Task<PaymentResponseDTO> UpdatePayment(int id, UpdatePaymentDTO dto);
        Task<bool> DeletePayment(int id);
        Task<PaymentResponseDTO> GetPaymentById(int id);
        Task<List<PaymentResponseDTO>> GetAllPayments();
    }
}
