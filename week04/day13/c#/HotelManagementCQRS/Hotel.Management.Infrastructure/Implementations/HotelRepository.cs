using Hotel.Management.Domain.Entities;
using Hotel.Management.Domain.Interfaces;
using Hotel.Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Management.Infrastructure.Implementations
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _dbcontext;

        public HotelRepository(HotelDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<HotelClass> AddHotelAsync(HotelClass hotel)
        {
            _dbcontext.Hotels.Add(hotel);
            await _dbcontext.SaveChangesAsync();
            return hotel;
        }
        public async Task UpdateHotelAsync(HotelClass hotel)
        {
            _dbcontext.Entry(hotel).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteHotelAsync(HotelClass hotel)
        {
            _dbcontext.Hotels.Remove(hotel);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<HotelClass> GetHotelByIdAsync(int id)
        {
            return await _dbcontext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task<List<HotelClass>> GetAllHotelsAsync()
        {
            return await _dbcontext.Hotels.ToListAsync();
        }
    }
}
