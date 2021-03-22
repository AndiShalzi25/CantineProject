using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCantineAPI.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public ICollection<WineBarrel> WineBarrels { get; set; }
    }
}
