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
    public class TipoRepository
    {
        private readonly PokedexContext _dbContext;

        public TipoRepository(PokedexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Tipo tipo)
        {
            await _dbContext.Tipos.AddAsync(tipo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Tipo tipo)
        {
            _dbContext.Entry(tipo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Tipo tipo)
        {
            _dbContext.Set<Tipo>().Remove(tipo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Tipo>> GetAllTiposAsync()
        {
            return await _dbContext.Set<Tipo>().ToListAsync();
        }

        public async Task<Tipo> GetByIdTipoAsync(int Id)
        {
            return await _dbContext.Set<Tipo>().FindAsync(Id);
        }

    }
}
