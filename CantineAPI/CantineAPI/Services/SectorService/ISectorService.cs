using CantineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantineAPI.DTOs.Sector;

namespace CantineAPI.Services.SectorService
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

        void Add(Sector sector);

        Task Delete(int id);
        Task<int> SaveChangesAsync();

        
    }
}
