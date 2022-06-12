using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository
    {
        private readonly PokedexContext _dbContext;

        public RegionRepository(PokedexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Region region)
        {
            await _dbContext.Regiones.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Region region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Region region)
        {
            _dbContext.Set<Region>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllRegionAsync()
        {
            return await _dbContext.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetByIdRegionAsync(int Id)
        {
            return await _dbContext.Set<Region>().FindAsync(Id);
        }

    }
}
