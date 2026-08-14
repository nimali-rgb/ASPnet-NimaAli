using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using CoreFitness.Web.Areas.Identity.Data;
using CoreFitness.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

namespace CoreFitness.Web.Controllers
{
    [Authorize]
    public class MyPageController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IBookingService _bookingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyPageController(
            IMembershipService membershipService,
            IBookingService bookingService,
            UserManager<ApplicationUser> userManager)
        {
            _membershipService = membershipService;
            _bookingService = bookingService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var membership = await _membershipService.GetMembershipByUserIdAsync(userId);
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);

            var vm = new MyPageViewModel
            {
                Membership = membership,
                Bookings = bookings.ToList(),

                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                MemberSince = membership?.CreatedAt,
                ProfileImageUrl = user.ProfileImageUrl ?? "/images/default-profile.png"
            };

            return View(vm);
        }
    }
}
