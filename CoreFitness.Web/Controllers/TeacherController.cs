using CoreFitness.Application.Services;
using CoreFitness.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService _service;

        public TeacherController(TeacherService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _service.GetAllAsync();
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            await _service.AddAsync(teacher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _service.GetByIdAsync(id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            await _service.UpdateAsync(teacher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _service.GetByIdAsync(id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _service.GetByIdAsync(id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }
    }
}
