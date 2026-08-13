using CoreFitness.Application.Services;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService _service;

        public BookingController(BookingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _service.GetAllAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
                return View(booking);

            await _service.AddAsync(booking);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null) return NotFound();

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Booking booking)
        {
            if (!ModelState.IsValid)
                return View(booking);

            await _service.UpdateAsync(booking);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null) return NotFound();

            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var booking = await _service.GetByIdAsync(id);
            if (booking == null) return NotFound();

            return View(booking);
        }
    }
}
