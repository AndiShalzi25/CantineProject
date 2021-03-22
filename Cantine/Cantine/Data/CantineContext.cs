using Cantine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Cantine.Data
{
    public class CantineContext : DbContext
    {
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<WineBarrel> WineBarrels { get; set; }
        public CantineContext(DbContextOptions<CantineContext> options) : base(options) { }


    }
}
