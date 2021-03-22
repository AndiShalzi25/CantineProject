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
   
    [ApiController]
    [Route("api/[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SectorsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectorDatabase()
        {
            return await _context.SectorDatabase.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sector = await _context.SectorDatabase.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, Sector sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.SectorDatabase.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sector>> DeleteSector(int id)
        {
            var sector = await _context.SectorDatabase.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.SectorDatabase.Remove(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        private bool SectorExists(int id)
        {
            return _context.SectorDatabase.Any(e => e.Id == id);
        }
    }
}
