using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAndi.Models;

namespace WebAppAndi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<SectorCategory> sectorCategories { get; set; }
        public DbSet<WineBarrelCategory> wineBarrelCategories { get; set; }
    }
}
