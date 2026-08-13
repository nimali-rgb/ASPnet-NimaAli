using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;

namespace CoreFitness.Application.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Booking>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Booking?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Booking booking) => _repo.AddAsync(booking);
        public Task UpdateAsync(Booking booking) => _repo.UpdateAsync(booking);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task BookAsync(Booking booking)
        {
            await _repo.AddAsync(booking);
        }

    }
}
