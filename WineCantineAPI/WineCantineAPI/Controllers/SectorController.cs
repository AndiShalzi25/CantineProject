using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCantineAPI.DTOs.Sector;
using WineCantineAPI.Models;
using WineCantineAPI.Services.SectorService;

namespace WineCantineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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



        //Using IActionResult because it enables us to send specific http status codes
        //back to the client together with the actual data that was requested

        public async Task<IActionResult> Get()
        {
            //await keyword in order to call a async method
            return Ok(await _sectorService.GetAllSectors()); //Send status code 200: OK
        }

        //Return 1st sector of the list
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _sectorService.GetSectorById(id));
            //returns the first id of the character that matches the given id
        }

        [HttpPost]
        //Change AddSector method parameter from Character to AddCharacterDTO
        public async Task<IActionResult> AddSector(AddSectorDTO newSector)
        {


            return Ok(await _sectorService.AddSector(newSector));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateSectorDTO updatedSector)
        {
            ServiceResponse<GetSectorDTO> response = await _sectorService.UpdateSector(updatedSector);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetSectorDTO>> response = await _sectorService.DeleteSector(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
