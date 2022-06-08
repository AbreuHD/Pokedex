using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {

        private readonly PokemonService _pokemonService;

        public PokemonController(PokedexContext dbContext)
        {
            _pokemonService = new(dbContext);
        }

        public async Task<IActionResult> PokemonForm()
        {
            return View(await _pokemonService.GetAllViewModel());
        }
        public IActionResult SavePoke()
        {
            return View(new PokemonViewModel());
        }
    }
}
