using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetBookingsForUserAsync(string userId);
    Task<Booking?> GetBookingByIdAsync(int id);
    Task CreateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int id);
}
