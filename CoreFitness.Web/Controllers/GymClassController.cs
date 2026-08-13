using CoreFitness.Application.Services;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers
{
    public class GymClassController : Controller
    {
        private readonly GymClassService _service;

        public GymClassController(GymClassService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await _service.GetAllAsync();
            return View(classes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GymClass gymClass)
        {
            if (!ModelState.IsValid)
                return View(gymClass);

            await _service.AddAsync(gymClass);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GymClass gymClass)
        {
            if (!ModelState.IsValid)
                return View(gymClass);

            await _service.UpdateAsync(gymClass);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var gymClass = await _service.GetByIdAsync(id);
            if (gymClass == null) return NotFound();

            return View(gymClass);
        }
    }
}
