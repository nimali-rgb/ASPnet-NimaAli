using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsByUserIdAsync(string userId);
        Task<bool> IsAlreadyBookedAsync(string userId, int gymClassId);
        Task AddAsync(Booking booking);
        Task RemoveAsync(int bookingId);
    }
}
