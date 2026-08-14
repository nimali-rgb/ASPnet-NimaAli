using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _repo;

        public MembershipService(IMembershipRepository repo)
        {
            _repo = repo;
        }

        public Task<Membership?> GetMembershipByUserIdAsync(string userId)
            => _repo.GetMembershipByUserIdAsync(userId);

        public Task CreateMembershipAsync(Membership membership)
            => _repo.AddAsync(membership);
    }
}
