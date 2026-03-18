using CoreFitness.Application.DTOs;

namespace CoreFitness.Application.Interfaces;

public interface IGymClassService
{
    Task CreateGymClassAsync(GymClassCreateDto dto);
    Task<IEnumerable<GymClassDto>> GetAllClassesAsync();
}