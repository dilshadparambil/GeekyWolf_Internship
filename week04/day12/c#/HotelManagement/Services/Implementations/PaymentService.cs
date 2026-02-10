
using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly HotelDbContext _contextdb;

        public PaymentService(HotelDbContext contextdb)
        {
            _contextdb = contextdb;
        }

        public async Task<PaymentResponseDTO> AddPayment(AddPaymentDTO dto)
        {
            var payment = new Payment
            {
                BookingId = dto.BookingId,
                Amount = dto.Amount,
                Method = (PaymentMethod)dto.Method,
                Status = PaymentStatus.Paid,
                PaymentDate = DateTime.UtcNow
            };

            _contextdb.Payments.Add(payment);
            await _contextdb.SaveChangesAsync();

            return new PaymentResponseDTO
            {
                Id = payment.Id,
                BookingId = payment.BookingId,
                Amount = payment.Amount,
                PaymentMethod = payment.Method.ToString(),
                Status = payment.Status.ToString(),
                PaymentDate = payment.PaymentDate
            };
        }

        public async Task<PaymentResponseDTO> UpdatePayment(int id, UpdatePaymentDTO dto)
        {
            var payment = await _contextdb.Payments.FindAsync(id);
            if (payment == null) return null;

            payment.Status = (PaymentStatus)dto.Status;
            await _contextdb.SaveChangesAsync();

            return new PaymentResponseDTO
            {
                Id = payment.Id,
                BookingId = payment.BookingId,
                Amount = payment.Amount,
                PaymentMethod = payment.Method.ToString(),
                Status = payment.Status.ToString(),
                PaymentDate = payment.PaymentDate
            };
        }

        public async Task<bool> DeletePayment(int id)
        {
            var payment = await _contextdb.Payments.FindAsync(id);
            if (payment == null) return false;

            _contextdb.Payments.Remove(payment);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<PaymentResponseDTO> GetPaymentById(int id)
        {
            var payment = await _contextdb.Payments.FindAsync(id);
            if (payment == null) return null;

            return new PaymentResponseDTO
            {
                Id = payment.Id,
                BookingId = payment.BookingId,
                Amount = payment.Amount,
                PaymentMethod = payment.Method.ToString(),
                Status = payment.Status.ToString(),
                PaymentDate = payment.PaymentDate
            };
        }

        public async Task<List<PaymentResponseDTO>> GetAllPayments()
        {
            return await _contextdb.Payments
                .Select(p => new PaymentResponseDTO
                {
                    Id = p.Id,
                    BookingId = p.BookingId,
                    Amount = p.Amount,
                    PaymentMethod = p.Method.ToString(),
                    Status = p.Status.ToString(),
                    PaymentDate = p.PaymentDate
                })
                .ToListAsync();
        }
    }
}
