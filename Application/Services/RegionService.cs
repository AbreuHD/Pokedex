﻿using Application.Repository;
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
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;
        public RegionService(PokedexContext dbContext)
        {
            _regionRepository = new (dbContext);
        }

        public async Task Add(RegionViewModel vm)
        {
            Region region = new();

            region.Name = vm.Name;
            region.Color = vm.Color;

            await _regionRepository.AddAsync(region);
        }

        public async Task Edit(RegionViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name;
            region.Color = vm.Color;
            region.Id = vm.Id;
            await _regionRepository.EditAsync(region);
        }

        public async Task Delete(int Id)
        {
            var Region = await _regionRepository.GetByIdRegionAsync(Id);
            await _regionRepository.DeleteAsync(Region);
        }

        public async Task<List<RegionViewModel>> GetRegionvm()
        {
            var RegionList = await _regionRepository.GetAllRegionAsync();
            return RegionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Color = region.Color,
                Name = region.Name
            }).ToList();
        }

        public async Task<RegionViewModel> GetByIdRegionViewModel(int Id)
        {
            var Tipo = await _regionRepository.GetByIdRegionAsync(Id);
            RegionViewModel vm = new();
            vm.Id = Tipo.Id;
            vm.Color = Tipo.Color;
            vm.Name = Tipo.Name;
            return vm;
        }
    }
}
