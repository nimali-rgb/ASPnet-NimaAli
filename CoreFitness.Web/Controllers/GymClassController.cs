using CoreFitness.Application.Services;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoreFitness.Web.Controllers
{
    [AllowAnonymous]
    public class GymClassController : Controller
    {
        private readonly GymClassService _service;

        public GymClassController(GymClassService service)
        {
            _service = service;
        }

        // ⭐ LISTA ALLA KLASSER
        public async Task<IActionResult> Index()
        {
            var classes = await _service.GetAllAsync();
            return View(classes);
        }

        // ⭐ CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // ⭐ CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(GymClass gymClass)
        {
            if (!ModelState.IsValid)
                return View(gymClass);

            await _service.AddAsync(gymClass);
            return RedirectToAction("Index");
        }

        // ⭐ EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        // ⭐ EDIT (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(GymClass gymClass)
        {
            if (!ModelState.IsValid)
                return View(gymClass);

            await _service.UpdateAsync(gymClass);
            return RedirectToAction("Index");
        }

        // ⭐ DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        // ⭐ DELETE (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        // ⭐ DELETE (POST)
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
