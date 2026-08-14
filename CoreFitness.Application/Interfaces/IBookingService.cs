using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces
{
    public interface IBookingService
    {
        Task<bool> BookAsync(string userId, int gymClassId);
        Task CancelAsync(int bookingId);
        Task<List<Booking>> GetBookingsByUserIdAsync(string userId);
    }
}
