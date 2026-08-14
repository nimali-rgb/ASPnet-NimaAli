using CoreFitness.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreFitness.Web.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // ⭐ Boka pass
        public async Task<IActionResult> Create(int gymClassId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);

            // Förhindra dubbelbokning
            if (bookings.Any(b => b.GymClassId == gymClassId))
            {
                TempData["Error"] = "Du har redan bokat detta pass.";
                return RedirectToAction("Index", "GymClass");
            }

            var success = await _bookingService.BookAsync(userId, gymClassId);

            if (!success)
            {
                TempData["Error"] = "Du har redan bokat detta pass.";
                return RedirectToAction("Index", "GymClass");
            }

            TempData["Success"] = "Du har bokat passet!";
            return RedirectToAction("MyBookings");
        }

        // ⭐ Avboka pass
        public async Task<IActionResult> Cancel(int id)
        {
            await _bookingService.CancelAsync(id);

            TempData["Success"] = "Du har avbokat passet.";
            return RedirectToAction("MyBookings");
        }

        // ⭐ Visa alla bokningar (Booking/Index)
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);

            return View(bookings);
        }

        // ⭐ MyBookings (huvudsidan för bokningar)
        public async Task<IActionResult> MyBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);

            return View(bookings);
        }
    }
}
