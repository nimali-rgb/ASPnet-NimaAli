using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces
{
    public interface IMembershipRepository
    {
        Task<Membership?> GetMembershipByUserIdAsync(string userId);
        Task AddAsync(Membership membership);
    }
}
