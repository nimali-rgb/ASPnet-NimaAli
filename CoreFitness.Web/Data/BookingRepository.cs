using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Web.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            return await _context.Bookings
                .Include(b => b.GymClass)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> IsAlreadyBookedAsync(string userId, int gymClassId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.GymClassId == gymClassId);
        }

        public async Task AddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
