using CoreFitness.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers;

public class GymClassController : Controller
{
    private readonly IGymClassService _gymClassService;

    public GymClassController(IGymClassService gymClassService)
    {
        _gymClassService = gymClassService;
    }

    public async Task<IActionResult> Index()
    {
        var classes = await _gymClassService.GetAllClassesAsync();
        return View(classes);
    }
}
