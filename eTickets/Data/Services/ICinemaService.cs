using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();

        Task<Cinema> GetByIdAsync(int id);

        Task AddAsync(Cinema cinema);

        Task UpdateAsync(Cinema Cinema);

        Task DeleteAsync(int id);
    }
}
