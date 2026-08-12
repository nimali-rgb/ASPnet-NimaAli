using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces;

public interface IGymClassService
{
    Task<IEnumerable<GymClass>> GetAllClassesAsync();
    Task<GymClass?> GetClassByIdAsync(int id);
    Task CreateClassAsync(GymClass gymClass);
    Task UpdateClassAsync(GymClass gymClass);
    Task DeleteClassAsync(int id);
}
