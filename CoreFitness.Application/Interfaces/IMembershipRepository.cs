using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> GetAllAsync();
        Task<Membership?> GetByIdAsync(int id);
        Task AddAsync(Membership membership);
        Task UpdateAsync(Membership membership);
        Task DeleteAsync(int id);
    }
}
