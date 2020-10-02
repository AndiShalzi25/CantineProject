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
    [ApiController]
    [Route("api/[controller]")]
    
    public class SectorsController : ControllerBase
    {
        private readonly CantineContext _context;

        public SectorsController(CantineContext context)
        {
            _context = context;
        }

        //Get all sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
        {
            return await _context.Sectors.ToListAsync();
        }

        //Get sector via Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        //Update sector
        [HttpPut]
        [Route("put/{id}")]
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

        //Create a sector       
        [HttpPost]
        [Route("post")]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        //Delete sector with corresponding id
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Sector>> DeleteSector(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        private bool SectorExists(int id)
        {
            return _context.Sectors.Any(e => e.Id == id);
        }
    }
}
