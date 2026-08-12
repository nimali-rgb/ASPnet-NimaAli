using CoreFitness.Domain.Entities;
using CoreFitness.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymClassesController : ControllerBase
    {
        private readonly CoreFitnessDbContext _context;

        public GymClassesController(CoreFitnessDbContext context)
        {
            _context = context;
        }

        // GET: api/gymclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymClass>>> GetGymClasses()
        {
            return await _context.GymClasses.ToListAsync();
        }

        // GET: api/gymclasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymClass>> GetGymClass(int id)
        {
            var gymClass = await _context.GymClasses.FindAsync(id);

            if (gymClass == null)
            {
                return NotFound();
            }

            return gymClass;
        }

        // POST: api/gymclasses
        [HttpPost]
        public async Task<ActionResult<GymClass>> PostGymClass(GymClass gymClass)
        {
            _context.GymClasses.Add(gymClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGymClass), new { id = gymClass.Id }, gymClass);
        }

        // PUT: api/gymclasses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymClass(int id, GymClass gymClass)
        {
            if (id != gymClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymClass).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/gymclasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymClass(int id)
        {
            var gymClass = await _context.GymClasses.FindAsync(id);

            if (gymClass == null)
            {
                return NotFound();
            }

            _context.GymClasses.Remove(gymClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
