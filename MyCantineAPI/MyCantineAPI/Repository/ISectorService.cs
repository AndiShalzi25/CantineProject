
using MyCantineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCantineAPI.Repository
{
    public interface ISectorService
    {
        void Add(Sector sector);
        Task Update(Sector sector);
        Task Delete(int id);
        Task<Sector> GetById(int id);
        Task<IEnumerable<Sector>> GetAll();

        Task<int> SaveChangesAsync();
    }
}
