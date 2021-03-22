using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAndi.Models
{
    public class SectorCategory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public ICollection<WineBarrelCategory> wineBarrelCategories { get; set; }
    }
}
