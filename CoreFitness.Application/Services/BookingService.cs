using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> BookAsync(string userId, int gymClassId)
        {
            if (await _repo.IsAlreadyBookedAsync(userId, gymClassId))
                return false;

            var booking = new Booking
            {
                UserId = userId,
                GymClassId = gymClassId,
                Date = DateTime.Now
            };

            await _repo.AddAsync(booking);
            return true;
        }

        public async Task CancelAsync(int bookingId)
        {
            await _repo.RemoveAsync(bookingId);
        }

        public Task<List<Booking>> GetBookingsByUserIdAsync(string userId)
            => _repo.GetBookingsByUserIdAsync(userId);
    }
}
