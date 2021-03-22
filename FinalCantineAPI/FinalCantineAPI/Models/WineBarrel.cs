using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Transactions;

namespace FinalCantineAPI.Models
{
    public class WineBarrel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description{ get; set; }
        public string Type { get; set; }
        public double Volume{ get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        

    }
}
