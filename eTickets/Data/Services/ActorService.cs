using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorService : IActorsService
    {
        private readonly AppDBContext _context;
        public ActorService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.ActorID == id);
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ActorID == id);
            if (result != null)
            {
                _context.Actors.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
