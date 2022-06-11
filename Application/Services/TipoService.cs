using Application.Repository;
using Application.ViewModels;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TipoService
    {
        private readonly TipoRepository _tipoRepository;
        public TipoService(PokedexContext dbContext)
        {
            _tipoRepository = new (dbContext);
        }

        public async Task Add(TipoViewModel vm)
        {
            Tipo tipo = new();

            tipo.Name = vm.Name;
            tipo.Color = vm.Color;

            await _tipoRepository.AddAsync(tipo);
        }

        public async Task Edit(TipoViewModel vm)
        {
            Tipo tipo = new();
            tipo.Name = vm.Name;
            tipo.Color = vm.Color;
            tipo.Id = vm.Id;
            await _tipoRepository.EditAsync(tipo);
        }

        public async Task Delete(int Id)
        {
            var Tipo = await _tipoRepository.GetByIdTipoAsync(Id);
            await _tipoRepository.DeleteAsync(Tipo);
        }

        public async Task<List<TipoViewModel>> GetTiposvm()
        {
            var TipoList = await _tipoRepository.GetAllTiposAsync();
            return TipoList.Select(tipo => new TipoViewModel
            {
                Id = tipo.Id,
                Color = tipo.Color,
                Name = tipo.Name
            }).ToList();
        }

        public async Task<TipoViewModel> GetByIdTipoViewModel(int Id)
        {
            var Tipo = await _tipoRepository.GetByIdTipoAsync(Id);
            TipoViewModel vm = new();
            vm.Id = Tipo.Id;
            vm.Color = Tipo.Color;
            vm.Name = Tipo.Name;
            return vm;
        }
    }
}
