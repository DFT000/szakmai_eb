using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szakmai_eb.Data;
using szakmai_eb.Models;

namespace szakmai_eb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersenyzokController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public VersenyzokController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Versenyzo>>> GetAll()
        {
            return await _context.Versenyzok
                .Include(v => v.Szakma)
                .Include(v => v.Orszag)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Versenyzo>> Get(int id)
        {
            var v = await _context.Versenyzok
                .Include(v => v.Szakma)
                .Include(v => v.Orszag)
                .FirstOrDefaultAsync(v => v.Id == id);

            return v == null ? NotFound() : v;
        }

        [HttpPost]
        public async Task<ActionResult<Versenyzo>> Post(Versenyzo v)
        {
            _context.Versenyzok.Add(v);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = v.Id }, v);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Versenyzo v)
        {
            if (id != v.Id) return BadRequest();
            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var v = await _context.Versenyzok.FindAsync(id);
            if (v == null) return NotFound();
            _context.Versenyzok.Remove(v);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}