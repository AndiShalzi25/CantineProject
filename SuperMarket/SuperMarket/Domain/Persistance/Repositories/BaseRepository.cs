using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Domain.Persistance.Repositories
{
    public class BaseRepository
    {
        public readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
