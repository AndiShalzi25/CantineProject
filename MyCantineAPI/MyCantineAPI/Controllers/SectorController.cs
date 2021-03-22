using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCantineAPI.Data;
using MyCantineAPI.Models;
using MyCantineAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCantineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet("Get")]
        
        public async Task<IEnumerable<Sector>> Get()
        {
            return await _sectorService.GetAll();
        }

        [HttpPost("Create")]
      
        public async Task<IActionResult> Add(Sector sector)
        {

            var newSct = new Sector
            {
                Description = sector.Description,
                Code = sector.Code,
                IsActive = sector.IsActive

            };

            _sectorService.Add(newSct);

            await _sectorService.SaveChangesAsync();

            return Ok(sector);
        }

        [HttpGet("Get/{id}")]
        
        public async Task<Sector> GetSectorId(int id)
        {
            var result = await _sectorService.GetById(id);
            
            return result;
        }

        [HttpPut("Edit")]
     
        public async Task Update([FromBody] Sector sector)
        {
            if (ModelState.IsValid)
            {
                await _sectorService.Update(sector);
            }
        }

        [HttpDelete("Delete/{id}")]
        
        public async Task Delete(int id)
        {
            await _sectorService.Delete(id);
        }
    }
}
