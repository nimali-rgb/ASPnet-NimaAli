using CoreFitness.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers;

public class MembershipController : Controller
{
    private readonly IMembershipService _membershipService;

    public MembershipController(IMembershipService membershipService)
    {
        _membershipService = membershipService;
    }

    // OFFENTLIG MEMBERSHIP PAGE
    public IActionResult Index()
    {
        return View();
    }

    // PRIVAT MEMBERSHIP PAGE
    public async Task<IActionResult> MyMembership()
    {
        string userId = "demo-user"; // fixas senare
        var membership = await _membershipService.GetMembershipForUserAsync(userId);
        return View(membership);
    }
}
