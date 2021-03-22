using Microsoft.EntityFrameworkCore;
using MyCantineAPI.Data;
using MyCantineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCantineAPI.Repository
{
    public class SectorService : ISectorService
    {
        private readonly DbContextClass db;

        public SectorService(DbContextClass _db)
        {
            db = _db;
        }


        public void Add(Sector sector)
        {
             db.SectorDB.Add(sector);
        }

        public async Task Delete(int id)
        {
            try
            {
                Sector sector = await db.SectorDB.FindAsync(id);
                db.SectorDB.Remove(sector);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Sector>> GetAll()
        {
            try
            {
                var sectors = await db.SectorDB.ToListAsync();
                return sectors.AsQueryable();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Sector> GetById(int id)
        {
            try
            {
                Sector sector = await db.SectorDB.FindAsync(id);
                if (sector == null)
                {
                    return null;
                }
                return sector;
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Sector sector)
        {
            try
            {
                db.Entry(sector).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }

       }
    }
        
