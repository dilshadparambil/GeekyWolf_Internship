using HotelMangement.Data;
using HotelMangement.Models.DTOs;
using HotelMangement.Models.Entities;
using HotelMangement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelMangement.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly HotelDbContext _contextdb;

        public ReviewService(HotelDbContext contextdb)
        {
            _contextdb = contextdb;
        }

        public async Task<ReviewResponseDTO> AddReview(AddReviewDTO dto)
        {
            var review = new Review
            {
                HotelId = dto.HotelId,
                CustomerId = dto.CustomerId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                ReviewDate = DateTime.UtcNow
            };

            _contextdb.Reviews.Add(review);
            await _contextdb.SaveChangesAsync();

            var hotel = await _contextdb.Hotels.FindAsync(dto.HotelId);
            var customer = await _contextdb.Customers.FindAsync(dto.CustomerId);

            return new ReviewResponseDTO
            {
                Id = review.Id,
                HotelName = hotel?.Name,
                CustomerName = customer?.FullName,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };
        }

        public async Task<ReviewResponseDTO> UpdateReview(int id, UpdateReviewDTO dto)
        {
            var review = await _contextdb.Reviews.FindAsync(id);
            if (review == null) return null;

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            await _contextdb.SaveChangesAsync();

            var hotel = await _contextdb.Hotels.FindAsync(review.HotelId);
            var customer = await _contextdb.Customers.FindAsync(review.CustomerId);

            return new ReviewResponseDTO
            {
                Id = review.Id,
                HotelName = hotel?.Name,
                CustomerName = customer?.FullName,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };
        }

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _contextdb.Reviews.FindAsync(id);
            if (review == null) return false;

            _contextdb.Reviews.Remove(review);
            await _contextdb.SaveChangesAsync();
            return true;
        }

        public async Task<ReviewResponseDTO> GetReviewById(int id)
        {
            var review = await _contextdb.Reviews
                .Include(r => r.Hotel)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null) return null;

            return new ReviewResponseDTO
            {
                Id = review.Id,
                HotelName = review.Hotel?.Name,
                CustomerName = review.Customer?.FullName,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };
        }

        public async Task<List<ReviewResponseDTO>> GetAllReviews()
        {
            return await _contextdb.Reviews
                .Include(r => r.Hotel)
                .Include(r => r.Customer)
                .Select(r => new ReviewResponseDTO
                {
                    Id = r.Id,
                    HotelName = r.Hotel.Name,
                    CustomerName = r.Customer.FullName,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    ReviewDate = r.ReviewDate
                })
                .ToListAsync();
        }
    }
}
