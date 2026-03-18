using CoreFitness.Application.DTOs;
using CoreFitness.Application.Interfaces;

namespace CoreFitness.Application.Services;

public class MembershipService : IMembershipService
{
    public Task CreateMembershipAsync(MembershipCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserHasMembershipAsync(string userId)
    {
        throw new NotImplementedException();
    }
}