using System;
using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using realEstateManagementBusinessLayer.Abstract;
using realEstateManagementDataLayer.Abstract;
using realEstateManagementEntities.Models;

namespace realEstateManagementBusinessLayer.Concrete
{
	public class EstateManager : IEstateService
    {
        private readonly IAsyncRepository<Estate> _asyncRepository;

        public EstateManager(IAsyncRepository<Estate> asyncRepository)
		{
            _asyncRepository = asyncRepository;
        }

        public async Task<Estate> AddEstate(Estate estate)
        {
            return await _asyncRepository.AddAsync(estate);
        }

        public async Task Delete(Estate estate)
        {
            await _asyncRepository.DeleteAsync(estate);
        }

        public async Task EditEstate(Estate estate)
        {
            await _asyncRepository.UpdateAsync(estate);
        }

        public async Task<Estate> GetByIdAsync(int id)
        {
            return await _asyncRepository.GetByIdAsync(id);
        }

        public async Task<List<Estate>> ListEstatesAsync(ISpecification<Estate> spec)
        {
            return await _asyncRepository.ListAsync(spec);
        }

        
    }
}

