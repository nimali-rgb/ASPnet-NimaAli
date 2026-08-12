using CoreFitness.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IActionResult> MyBookings()
    {
        string userId = "demo-user"; // vi fixar riktig user senare
        var bookings = await _bookingService.GetBookingsForUserAsync(userId);
        return View(bookings);
    }
}
