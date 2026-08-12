using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services;

public class MembershipService : IMembershipService
{
    private readonly IMembershipRepository _membershipRepository;

    public MembershipService(IMembershipRepository membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public async Task<Membership?> GetMembershipForUserAsync(string userId)
        => await _membershipRepository.GetByUserIdAsync(userId);

    public async Task CreateMembershipAsync(Membership membership)
        => await _membershipRepository.AddAsync(membership);

    public async Task UpdateMembershipAsync(Membership membership)
        => await _membershipRepository.UpdateAsync(membership);

    public async Task DeleteMembershipAsync(int id)
    {
        var membership = await _membershipRepository.GetByIdAsync(id);
        if (membership != null)
            await _membershipRepository.DeleteAsync(membership);
    }
}
