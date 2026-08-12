

using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces;

public interface IMembershipRepository
{
    Task<Membership?> GetByUserIdAsync(string userId);
    Task<Membership?> GetByIdAsync(int id);
    Task AddAsync(Membership membership);
    Task UpdateAsync(Membership membership);
    Task DeleteAsync(Membership membership);
}
