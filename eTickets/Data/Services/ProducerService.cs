using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProducerService : IProducersService
    {
        private readonly AppDBContext _context;
        public ProducerService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            return await _context.Producers.ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(a => a.ProducerID == id);
        }

        public async Task AddAsync(Producer Producer)
        {
            await _context.Producers.AddAsync(Producer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producer Producer)
        {
            _context.Update(Producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.ProducerID == id);
            if (result != null)
            {
                _context.Producers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
