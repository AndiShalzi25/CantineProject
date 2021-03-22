using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalCantineAPI.Data;
using FinalCantineAPI.Models;

namespace FinalCantineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineBarrelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WineBarrelsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineBarrel>>> GetWineBarrelDatabase()
        {
            return await _context.WineBarrelDatabase.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WineBarrel>> GetWineBarrel(int id)
        {
            var wineBarrel = await _context.WineBarrelDatabase.FindAsync(id);

            if (wineBarrel == null)
            {
                return NotFound();
            }

            return wineBarrel;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWineBarrel(int id, WineBarrel wineBarrel)
        {
            if (id != wineBarrel.Id)
            {
                return BadRequest();
            }

            _context.Entry(wineBarrel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineBarrelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<WineBarrel>> PostWineBarrel(WineBarrel wineBarrel)
        {
            _context.WineBarrelDatabase.Add(wineBarrel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWineBarrel", new { id = wineBarrel.Id }, wineBarrel);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<WineBarrel>> DeleteWineBarrel(int id)
        {
            var wineBarrel = await _context.WineBarrelDatabase.FindAsync(id);
            if (wineBarrel == null)
            {
                return NotFound();
            }

            _context.WineBarrelDatabase.Remove(wineBarrel);
            await _context.SaveChangesAsync();

            return wineBarrel;
        }

        private bool WineBarrelExists(int id)
        {
            return _context.WineBarrelDatabase.Any(e => e.Id == id);
        }
    }
}
