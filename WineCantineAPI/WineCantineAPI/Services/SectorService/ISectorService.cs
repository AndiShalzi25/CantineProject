using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCantineAPI.DTOs.Sector;
using WineCantineAPI.Models;

namespace WineCantineAPI.Services.SectorService
{
    public interface ISectorService
    {
        //Adding serviceResponse
        //Instead of Character we now return a DTO
        Task<ServiceResponse<List<GetSectorDTO>>> GetAllSectors();

        Task<ServiceResponse<GetSectorDTO>> GetSectorById(int id);

        //The parameter of AddCharacter is now AddCharacterDTO
        Task<ServiceResponse<List<GetSectorDTO>>> AddSector(AddSectorDTO newSector);

        Task<ServiceResponse<GetSectorDTO>> UpdateSector(UpdateSectorDTO updateSector);

        Task<ServiceResponse<List<GetSectorDTO>>> DeleteSector(int id);
    }
}
