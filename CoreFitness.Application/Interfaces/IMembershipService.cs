using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces
{
    public interface IMembershipService
    {
        Task<Membership?> GetMembershipByUserIdAsync(string userId);
        Task CreateMembershipAsync(Membership membership);
    }
}
