using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCantineAPI.DTOs.Sector;
using WineCantineAPI.Models;
using WineCantineAPI.Services.SectorService;

namespace WineCantineAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Creating a map for the nessecary mapping (getting sectors)

            CreateMap<Sector, GetSectorDTO>();


        //Creating a map for the nessecary mapping (adding sectors)

            CreateMap<AddSectorDTO, Sector>();
        }
        
    }

    
}
