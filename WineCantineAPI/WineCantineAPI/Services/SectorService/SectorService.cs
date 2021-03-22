using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCantineAPI.DTOs.Sector;
using WineCantineAPI.Models;

namespace WineCantineAPI.Services.SectorService
{
    public class SectorService : ISectorService
    {
        private static List<Sector> sectorList = new List<Sector>
        {
            new Sector(),
            new Sector {Id = 1, Description = "Hello!!!"}
        };

        //Initializing IMapper parameter
        private readonly IMapper _mapper;


        //To use AutoMapper we need an instance of it by creating a contructor and injecting IMapper
        public SectorService(IMapper mapper)
        {
            _mapper = mapper;
        }


        //Adding ServiceResponse
        //Replacing Character with corresponding DTO
        public async Task<ServiceResponse<List<GetSectorDTO>>> AddSector(AddSectorDTO newSector)
        {

            //Creating a new ServiceResponse Object pf type list sector

            ServiceResponse<List<GetSectorDTO>> serviceResponse = new ServiceResponse<List<GetSectorDTO>>();


            Sector sector = _mapper.Map<Sector>(newSector);//Firstly mapping the new sector into sector type because it
                                                                       //will be added to the sectors list


            sector.Id = sectorList.Max(c => c.Id) + 1; //Since we cannot add Character id manually for each Character added increase the id by 1

            sectorList.Add(sector);


            //Set serviceResponse data to the sectors and return it
            //Map the details with the model
            //Mapping the whole sector list in one line and give it to serviceResponse using Select()

            serviceResponse.Data = (sectorList.Select(c => _mapper.Map<GetSectorDTO>(c))).ToList();
            //Mapping all Sector object of the list into a DTO

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetSectorDTO>>> GetAllSectors()
        {
            ServiceResponse<List<GetSectorDTO>> serviceResponse = new ServiceResponse<List<GetSectorDTO>>();


            //Set serviceResponse data to the characters and return it
            //Map the details with the model
            //Mapping the whole character list in one line and give it to serviceResponse using Select()

            //Mapping all character object of the list into a DTO
            serviceResponse.Data = (sectorList.Select(c => _mapper.Map<GetSectorDTO>(c))).ToList();

            return serviceResponse;
        }


        public async Task<ServiceResponse<GetSectorDTO>> GetSectorById(int id)
        {
            ServiceResponse<GetSectorDTO> serviceResponse = new ServiceResponse<GetSectorDTO>();

            //Set the serviceResponse data to the character with the given id and return it
            //_mapper.Map which type of value should be mapped to and the parameter is DTO object that shall be mapped
            serviceResponse.Data = _mapper.Map<GetSectorDTO>((sectorList.FirstOrDefault(c => c.Id == id)));
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetSectorDTO>> UpdateSector(UpdateSectorDTO updateSector)
        {
            ServiceResponse<GetSectorDTO> serviceResponse = new ServiceResponse<GetSectorDTO>();

            try
            {
                Sector sector = sectorList.FirstOrDefault(c => c.Id == updateSector.Id);

                sector.Description = updateSector.Description;
                sector.Code = updateSector.Code;
                sector.isActive = updateSector.isActive;


                //Mapping character to the DTO and return serviceResponse
                serviceResponse.Data = _mapper.Map<GetSectorDTO>(sector);
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<GetSectorDTO>>> DeleteSector(int id)
        {
            ServiceResponse<List<GetSectorDTO>> serviceResponse = new ServiceResponse<List<GetSectorDTO>>();


            try
            {
                Sector sector = sectorList.First(c => c.Id == id);

                sectorList.Remove(sector);

                //Mapping character to the DTO and return serviceResponse
                serviceResponse.Data = (sectorList.Select(c => _mapper.Map<GetSectorDTO>(c))).ToList();
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;



        }
    }
}
