﻿using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly PokedexContext _dbContext;
        public PokemonRepository(PokedexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task EditAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemon>().ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(Id);
        }
    }
}
