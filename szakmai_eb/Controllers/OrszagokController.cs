using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szakmai_eb.Data;
using szakmai_eb.Models;

namespace szakmai_eb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrszagokController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public OrszagokController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orszag>>> GetAll() =>
            await _context.Orszagok.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Orszag>> Get(string id)
        {
            var o = await _context.Orszagok.FindAsync(id);
            return o == null ? NotFound() : o;
        }

        [HttpPost]
        public async Task<ActionResult<Orszag>> Post(Orszag o)
        {
            _context.Orszagok.Add(o);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = o.Id }, o);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Orszag o)
        {
            if (id != o.Id) return BadRequest();
            _context.Entry(o).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var o = await _context.Orszagok.FindAsync(id);
            if (o == null) return NotFound();
            _context.Orszagok.Remove(o);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
