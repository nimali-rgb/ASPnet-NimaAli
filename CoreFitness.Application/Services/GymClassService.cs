using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services;

public class GymClassService : IGymClassService
{
    private readonly IGymClassRepository _gymClassRepository;

    public GymClassService(IGymClassRepository gymClassRepository)
    {
        _gymClassRepository = gymClassRepository;
    }

    public async Task<IEnumerable<GymClass>> GetAllClassesAsync()
        => await _gymClassRepository.GetAllAsync();

    public async Task<GymClass?> GetClassByIdAsync(int id)
        => await _gymClassRepository.GetByIdAsync(id);

    public async Task CreateClassAsync(GymClass gymClass)
        => await _gymClassRepository.AddAsync(gymClass);

    public async Task UpdateClassAsync(GymClass gymClass)
        => await _gymClassRepository.UpdateAsync(gymClass);

    public async Task DeleteClassAsync(int id)
    {
        var gymClass = await _gymClassRepository.GetByIdAsync(id);
        if (gymClass != null)
            await _gymClassRepository.DeleteAsync(gymClass);
    }
}
