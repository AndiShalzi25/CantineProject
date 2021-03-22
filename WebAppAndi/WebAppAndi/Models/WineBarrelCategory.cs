using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAndi.Models
{
    public class WineBarrelCategory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public double Volume { get; set; }
        public string type { get; set; }
        public int SectorCategoryId { get; set; }
        public SectorCategory SectorCategory { get; set; }
    }
}
