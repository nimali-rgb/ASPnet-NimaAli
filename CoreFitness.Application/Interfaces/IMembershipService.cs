using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces;

public interface IMembershipService
{
    Task<Membership?> GetMembershipForUserAsync(string userId);
    Task CreateMembershipAsync(Membership membership);
    Task UpdateMembershipAsync(Membership membership);
    Task DeleteMembershipAsync(int id);
}
