using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDBContext _context;
        public CinemaService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(a => a.MovieId == id);
        }

        public async Task AddAsync(Cinema Cinema)
        {
            await _context.Cinemas.AddAsync(Cinema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cinema Cinema)
        {
            _context.Update(Cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.MovieId == id);
            if (result != null)
            {
                _context.Cinemas.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
