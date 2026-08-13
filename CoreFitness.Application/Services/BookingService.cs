using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

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

    // NY METOD
    public async Task<bool> BookAsync(string userId, int gymClassId)
    {
        var bookings = await _bookingRepository.GetByUserIdAsync(userId);

        if (bookings.Any(b => b.GymClassId == gymClassId))
            return false;

        var booking = new Booking
        {
            UserId = userId,
            GymClassId = gymClassId,
            CreatedAt = DateTime.Now
        };

        await _bookingRepository.AddAsync(booking);
        return true;
    }
}
