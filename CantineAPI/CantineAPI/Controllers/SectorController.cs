using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantineAPI.DTOs.Sector;
using CantineAPI.Models;
using CantineAPI.Services.SectorService;

namespace CantineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //Base class without view support
    public class SectorController : ControllerBase
    {

        private static List<Sector> sectorList = new List<Sector>
        {
            new Sector(),
            new Sector {Id = 1, Description = "Hello there!!!"}
        };

        private readonly ISectorService _sectorService;
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        /*Using IActionResult because it enables us to send specific http status codes
          back to the client together with the actual data that was requested*/

        public async Task<IActionResult> Get()
        {
            //await keyword in order to call a async method
            return Ok(await _sectorService.GetAllSectors()); //Send status code 200: OK
        }

        //Return sector by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _sectorService.GetSectorById(id));
            //returns the first id of the character that matches the given id un url
        }

        [HttpPost]
        //Change AddSector method parameter from Sector to AddCharacterDTO
        public async Task<IActionResult> AddSector(AddSectorDTO newSector)
        {


            return Ok(await _sectorService.AddSector(newSector));
        }

        [HttpPost("Add")]
        //Change AddSector method parameter from Sector to AddCharacterDTO
        public async Task<IActionResult> Add(AddSectorDTO sectorDTO)
        {

            var sector = new Sector
            {
                Code = sectorDTO.Code,
                Description = sectorDTO.Description,
                isActive = sectorDTO.isActive

            };

            _sectorService.Add(sector);

            await _sectorService.SaveChangesAsync();

            return Ok(sector);
        }
       

        

        [HttpPut("Put")]
        public async Task<IActionResult> UpdateSector(UpdateSectorDTO updatedSector)
        {
            ServiceResponse<GetSectorDTO> response = await _sectorService.UpdateSector(updatedSector);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


       // [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetSectorDTO>> response = await _sectorService.DeleteSector(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("Delete")]
       
        public async Task Dele(int id)
        {
            await _sectorService.Delete(id);
            
        }

    }
}
