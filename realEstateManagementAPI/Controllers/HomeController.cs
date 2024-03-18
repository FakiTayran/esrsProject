using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using realEstateManagementBusinessLayer.Abstract;
using realEstateManagementBusinessLayer.Concrete.Spesification;
using realEstateManagementDataLayer.EntityFramework;
using realEstateManagementEntities.Models;
using realEstateManagementEntities.Models.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace realEstateManagementAPI.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly RealEstateManagementDbContext? _context;

        public HomeController(IEstateService estateService, RealEstateManagementDbContext realEstateManagementDbContext)
        {
            _estateService = estateService;
            _context = realEstateManagementDbContext;
        }


        [HttpGet("GetAllEstates")]
        public async Task<IActionResult> GetAllEstates(EstateType? estateType = null, PropertyType? propertyType = null, int? numberOfRooms = null, string? city = null, string? postCode = null, string? searchText = null, string? adminUserId = null)
        {
            var spec = new EstateFilterSpesification(estateType, propertyType, numberOfRooms, city, postCode, searchText, adminUserId);
            List<EstateDto> estateDtos = await _estateService.ListEstatesAsync(spec); 
            
            return Ok(estateDtos);
        }

    }
}

