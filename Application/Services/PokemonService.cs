using Database;
using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Database.Models;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;
        public PokemonService(PokedexContext dbContext)
        {
            _pokemonRepository = new (dbContext);
        }

        public async Task Add(PokemonViewModel vm)
        {
            Pokemon pokemon = new();
            
            pokemon.Name = vm.Name;
            //pokemon.Id = vm.Id;
            pokemon.TipoId = vm.TipoId;
            pokemon.TipoIdSec = vm.TipoIdSec;
            pokemon.ImgUrl = vm.ImgUrl;
            pokemon.RegionId = vm.RegionId;
            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task Edit(PokemonViewModel vm)
        {
            Pokemon pokemon = new();

            pokemon.Name = vm.Name;
            pokemon.Id = vm.Id;
            pokemon.TipoId = vm.TipoId;
            pokemon.TipoIdSec = vm.TipoIdSec;
            pokemon.ImgUrl = vm.ImgUrl;
            pokemon.RegionId = vm.RegionId;
            await _pokemonRepository.EditAsync(pokemon);
        }

        public async Task Delete(int Id)
        {
            var Pokemon = await _pokemonRepository.GetByIdAsync(Id);
            await _pokemonRepository.DeleteAsync(Pokemon);
        }

        public async Task<PokemonViewModel> GetByIdPokemonViewModel(int Id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(Id);
            PokemonViewModel poke = new();
            poke.Id = pokemon.Id;
            poke.TipoId = pokemon.TipoId;
            poke.TipoIdSec = pokemon.TipoIdSec;
            poke.ImgUrl = pokemon.ImgUrl;
            poke.RegionId = pokemon.RegionId;
            poke.Name = pokemon.Name;
            
            return poke;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImgUrl = pokemon.ImgUrl,
                RegionId = pokemon.RegionId,
                TipoId = pokemon.TipoId,
                TipoIdSec = pokemon.TipoIdSec
            }).ToList();
        }
    }
}
