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
        private readonly TipoService _tipoService;
        private readonly RegionService _regionService;



        public PokemonController(PokedexContext dbContext)
        {
            _pokemonService = new(dbContext);
            _tipoService = new(dbContext);
            _regionService = new(dbContext);

        }

        /*public IActionResult SavePoke()
        {
            return View(new PokemonViewModel());
        }*/

        public async Task<IActionResult> PokemonForm()
        {
            return View(await _pokemonService.GetAll());
        }

        public async Task<IActionResult> SavePoke()
        {
            ViewBag.Tipo = await _tipoService.GetTiposvm();
            ViewBag.Region = await _regionService.GetRegionvm();
            return View(new PokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SavePoke(PokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            { 
                ViewBag.Tipo = await _tipoService.GetTiposvm();
                ViewBag.Region = await _regionService.GetRegionvm();
                return View(vm); 
            }

            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemon", Action = "PokemonForm" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.Tipo = await _tipoService.GetTiposvm();
            ViewBag.Region = await _regionService.GetRegionvm();
            return View(await _pokemonService.GetByIdPokemonViewModel(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tipo = await _tipoService.GetTiposvm();
                ViewBag.Region = await _regionService.GetRegionvm();
                return View( vm);
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
