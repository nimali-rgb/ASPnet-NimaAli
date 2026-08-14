using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreFitness.Web.Controllers
{
    [Authorize]
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                TempData["Error"] = "Kunde inte hitta användaren.";
                return RedirectToAction("Index", "MyPage");
            }

            // Skapa nytt medlemskap-objekt
            var membership = new Membership
            {
                Type = "Standard",
                Price = 299,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            // Skicka rätt typ till service
            await _membershipService.CreateMembershipAsync(membership);

            TempData["Success"] = "Medlemskap skapat!";
            return RedirectToAction("Index", "MyPage");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var membership = await _membershipService.GetMembershipByUserIdAsync(userId);

            return View(membership);
        }
    }
}
