
using HotelMangement.Models.DTOs;

namespace HotelMangement.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewResponseDTO> AddReview(AddReviewDTO dto);
        Task<ReviewResponseDTO> UpdateReview(int id, UpdateReviewDTO dto);
        Task<bool> DeleteReview(int id);
        Task<ReviewResponseDTO> GetReviewById(int id);
        Task<List<ReviewResponseDTO>> GetAllReviews();
    }
}
