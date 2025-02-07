using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAllAsync();

        Task<Producer> GetByIdAsync(int id);

        Task AddAsync(Producer Producer);

        Task UpdateAsync(Producer Producer);

        Task DeleteAsync(int id);
    }
}
