using CoreFitness.Application.DTOs;
using CoreFitness.Application.Interfaces;

namespace CoreFitness.Application.Services;

public class BookingService : IBookingService
{
    public Task<bool> CreateBookingAsync(BookingCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookingDto>> GetBookingsForUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}