

using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetByUserIdAsync(string userId);
    Task<Booking?> GetByIdAsync(int id);
    Task AddAsync(Booking booking);
    Task DeleteAsync(Booking booking);
}
