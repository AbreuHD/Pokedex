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

        public IActionResult SavePoke()
        {
            return View(new PokemonViewModel());
        }

        public async Task<IActionResult> PokemonForm()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePoke", new PokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePoke", vm); 
            }
            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", Action = "PokemonForm" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SavePoke", await _pokemonService.GetByIdPokemonViewModel(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePoke", vm);
            }
            await _pokemonService.Edit(vm);
            return RedirectToRoute(new { controller = "Pokemon", Action = "PokemonForm" });
        }


        public async Task<IActionResult> Delete(int Id)
        {
            return View(await _pokemonService.GetByIdPokemonViewModel(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _pokemonService.Delete(Id);
            return RedirectToRoute(new { controller = "Pokemon", Action = "PokemonForm" });
        }

    }
}
