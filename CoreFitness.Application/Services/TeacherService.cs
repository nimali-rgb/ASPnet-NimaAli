using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class TeacherService
    {
        private readonly ITeacherRepository _repo;

        public TeacherService(ITeacherRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Teacher>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Teacher?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Teacher teacher) => _repo.AddAsync(teacher);
        public Task UpdateAsync(Teacher teacher) => _repo.UpdateAsync(teacher);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
