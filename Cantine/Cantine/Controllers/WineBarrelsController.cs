using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cantine.Data;
using Cantine.Models;

namespace Cantine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineBarrelsController : ControllerBase
    {
        private readonly CantineContext _context;

        public WineBarrelsController(CantineContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WineBarrel>>> GetWineBarrels()
        {
            return await _context.WineBarrels.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<WineBarrel>> GetWineBarrel(int id)
        {
            var wineBarrel = await _context.WineBarrels.FindAsync(id);

            if (wineBarrel == null)
            {
                return NotFound();
            }

            return wineBarrel;
        }

        [HttpPut]
        [Route("put/{id}")]
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
        [Route("post")]
        public async Task<ActionResult<WineBarrel>> PostWineBarrel(WineBarrel wineBarrel)
        {
            _context.WineBarrels.Add(wineBarrel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWineBarrel", new { id = wineBarrel.Id }, wineBarrel);
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<WineBarrel>> DeleteWineBarrel(int id)
        {
            var wineBarrel = await _context.WineBarrels.FindAsync(id);
            if (wineBarrel == null)
            {
                return NotFound();
            }

            _context.WineBarrels.Remove(wineBarrel);
            await _context.SaveChangesAsync();

            return wineBarrel;
        }

        private bool WineBarrelExists(int id)
        {
            return _context.WineBarrels.Any(e => e.Id == id);
        }
    }
}
