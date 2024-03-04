using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using realEstateManagementBusinessLayer.Abstract;
using realEstateManagementBusinessLayer.Concrete.Spesification;
using realEstateManagementDataLayer.EntityFramework;
using realEstateManagementEntities.Models;

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
        // GET: /<controller>/
        [HttpGet("GetEstates/{estateType}/{propertyType}/{numberOfRooms}/{city}/{postCode}/{searchText}")]

        public async Task<IActionResult> GetEstates(EstateType? estateType, PropertyType? propertyType, int? numberOfRooms, string? city, string? postCode, string? searchText, string? adminUserId)
        {
            var spec = new EstateFilterSpesification(estateType, propertyType, numberOfRooms, city, postCode, searchText, adminUserId);
            var estates = _estateService.ListEstatesAsync(spec);

            return Ok(estates);
        }


    }
}

