using CoreFitness.Application.DTOs;
using CoreFitness.Application.Interfaces;

namespace CoreFitness.Application.Services;

public class GymClassService : IGymClassService
{
    public Task CreateGymClassAsync(GymClassCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GymClassDto>> GetAllClassesAsync()
    {
        throw new NotImplementedException();
    }
}