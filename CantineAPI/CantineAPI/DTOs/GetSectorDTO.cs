using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CantineAPI.DTOs.Sector
{
    //Same properties as Sector
    public class GetSectorDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool isActive { get; set; }
    }
}
