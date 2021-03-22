using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantineAPI.DTOs.Sector;
using CantineAPI.Models;
using CantineAPI.Services.SectorService;

namespace CantineAPI
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
