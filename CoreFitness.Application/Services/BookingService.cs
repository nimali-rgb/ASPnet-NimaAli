using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<IEnumerable<Booking>> GetBookingsForUserAsync(string userId)
        => await _bookingRepository.GetByUserIdAsync(userId);

    public async Task<Booking?> GetBookingByIdAsync(int id)
        => await _bookingRepository.GetByIdAsync(id);

    public async Task CreateBookingAsync(Booking booking)
        => await _bookingRepository.AddAsync(booking);

    public async Task DeleteBookingAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking != null)
            await _bookingRepository.DeleteAsync(booking);
    }
}
