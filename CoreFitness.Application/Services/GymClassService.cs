using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class GymClassService
    {
        private readonly IGymClassRepository _repo;

        public GymClassService(IGymClassRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<GymClass>> GetAllAsync() => _repo.GetAllAsync();
        public Task<GymClass?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(GymClass gymClass) => _repo.AddAsync(gymClass);
        public Task UpdateAsync(GymClass gymClass) => _repo.UpdateAsync(gymClass);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
