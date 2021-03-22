using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CantineAPI.DTOs.Sector
{
    //Small object that do not consist of each roperty of the corresponding model
    //Map certain properties of the model to the DTO( returning data to the clients)
    public class AddSectorDTO
    {
        //Not adding id property
        public string Description { get; set; }
        public string Code { get; set; }
        public bool isActive { get; set; }
    }
}
