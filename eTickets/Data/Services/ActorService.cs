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
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n=>n.ActorID == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> UpdateAsync(Actor Actor)
        {
            _context.Update(Actor);
            await _context.SaveChangesAsync();
            return Actor;
        }
    }
}
