using CoreFitness.Application.DTOs;

namespace CoreFitness.Application.Interfaces;

public interface IMembershipService
{
    Task CreateMembershipAsync(MembershipCreateDto dto);
    Task<bool> UserHasMembershipAsync(string userId);
}