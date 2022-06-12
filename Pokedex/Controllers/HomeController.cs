using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly TipoService _tipoService;
        private readonly RegionService _regionService;

        public HomeController(PokedexContext dbContext)
        {
            _pokemonService = new(dbContext);
            _tipoService = new(dbContext);
            _regionService = new(dbContext);
        }

        public async Task<IActionResult> Index(int Id = 0)
        {
            ViewBag.Region = await _regionService.GetRegionvm();
            ViewBag.Filtro = Id;
            return View(await _pokemonService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Index(String Busqueda = null, int Id = 0)
        {
            ViewBag.Region = await _regionService.GetRegionvm();
            ViewBag.Filtro = Id;
            ViewBag.Busqueda = Busqueda;
            return View(await _pokemonService.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
