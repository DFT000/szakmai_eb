using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szakmai_eb.Data;
using szakmai_eb.Models;

namespace szakmai_eb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzakmakController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public SzakmakController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szakma>>> GetAll() =>
            await _context.Szakmak.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Szakma>> Get(string id)
        {
            var item = await _context.Szakmak.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Szakma>> Post(Szakma s)
        {
            _context.Szakmak.Add(s);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Szakma s)
        {
            if (id != s.Id) return BadRequest();
            _context.Entry(s).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var s = await _context.Szakmak.FindAsync(id);
            if (s == null) return NotFound();
            _context.Szakmak.Remove(s);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
