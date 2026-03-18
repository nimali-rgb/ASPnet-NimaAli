using CoreFitness.Application.DTOs;

namespace CoreFitness.Application.Interfaces;

public interface IBookingService
{
    Task<bool> CreateBookingAsync(BookingCreateDto dto);
    Task<IEnumerable<BookingDto>> GetBookingsForUserAsync(string userId);
}