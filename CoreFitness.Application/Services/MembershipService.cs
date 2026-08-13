using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class MembershipService
    {
        private readonly IMembershipRepository _repo;

        public MembershipService(IMembershipRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Membership>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Membership?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Membership membership) => _repo.AddAsync(membership);
        public Task UpdateAsync(Membership membership) => _repo.UpdateAsync(membership);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
