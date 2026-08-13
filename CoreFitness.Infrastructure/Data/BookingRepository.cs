using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Infrastructure.Data;

public class BookingRepository : IBookingRepository
{
    private readonly CoreFitnessDbContext _context;

    public BookingRepository(CoreFitnessDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetByUserIdAsync(string userId)
    {
        return await _context.Bookings
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
        => await _context.Bookings.FindAsync(id);

    public async Task AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Booking booking)
    {
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }
}
