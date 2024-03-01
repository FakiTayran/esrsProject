using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using realEstateManagementBusinessLayer.Abstract;
using realEstateManagementBusinessLayer.Concrete.Spesification;
using realEstateManagementDataLayer.EntityFramework;
using realEstateManagementEntities.Models;
using realEstateManagementEntities.Models.Dtos;


namespace realEstateManagementAPI.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IAgentService _customerService;
        private readonly IEstateService _estateService;
        private readonly IEstatePictureService _estatePictureService;
        private readonly RealEstateManagementDbContext? _context;

        public AdminController(IEstateService estateService,IEstatePictureService estatePictureService,RealEstateManagementDbContext realEstateManagementDbContext)
        {
            _estateService = estateService;
            _context = realEstateManagementDbContext;
            _estatePictureService = estatePictureService;
        }
        // GET: /<controller>/
        [HttpGet("GetEstates")]
        public async Task<IActionResult> GetEstates(EstateType? estateType = null, PropertyType? propertyType = null, int? numberOfRooms = null, string? city = null, string? postCode = null, string? searchText = null, string? adminUserId = null)
        {
            var spec = new EstateFilterSpesification(estateType, propertyType, numberOfRooms, city, postCode, searchText, adminUserId);
            var estates = await _estateService.ListEstatesAsync(spec); // Ensure this call is awaited

            return Ok(estates);
        }


        [HttpPost("AddEstate")]
        public async Task<IActionResult> AddEstate(Estate estate)
        {
            if (!string.IsNullOrEmpty(estate.City) || !string.IsNullOrEmpty(estate.PostCode) || !string.IsNullOrEmpty(estate.Description) || !string.IsNullOrEmpty(estate.Headline))
            {
                await _estateService.AddEstate(estate);
            }
            else
            {
                return BadRequest();
            }
            return Ok(new GeneralResponse<string>
            {
                Result = "Some of these values might be null or empty (city,postcode,description and headline)",
                IsError = true,
                Code = 1
            });
        }

        [HttpPut("EditEstate")]
        public async Task<IActionResult> EditEstate(Estate estate)
        {
            var willBeUpdatedEstate = await _estateService.GetByIdAsync(estate.Id);
            willBeUpdatedEstate.EstateType = estate.EstateType;
            willBeUpdatedEstate.PropertyType = estate.PropertyType;
            willBeUpdatedEstate.PostCode = estate.PostCode;
            willBeUpdatedEstate.NumberOfRooms = estate.NumberOfRooms;
            willBeUpdatedEstate.Headline = estate.Headline;
            willBeUpdatedEstate.EstateAgent = estate.EstateAgent;
            willBeUpdatedEstate.City = estate.City;
            if (!string.IsNullOrEmpty(estate.City) || !string.IsNullOrEmpty(estate.PostCode) || !string.IsNullOrEmpty(estate.Description) || !string.IsNullOrEmpty(estate.Headline))
            {
                await _estateService.EditEstate(willBeUpdatedEstate);
            }
            else
            {
                return BadRequest();
            }
            return BadRequest(new GeneralResponse<string>
            {
                Result = "Some of these values might be null or empty (city,postcode,description and headline)",
                IsError = true,
                Code = 1
            });
        }
        [HttpDelete("DeleteEstate/{estateId}")]
        public async Task<IActionResult> DeleteEstate(int estateId)
        {
            var willBeDeletedEstate = await _estateService.GetByIdAsync(estateId);
            if (willBeDeletedEstate == null)
            {
                return NotFound($"Estate with ID {estateId} not found.");
            }
            await _estateService.Delete(willBeDeletedEstate);
            return Ok(estateId);
        }

        [HttpGet("GetEstateDetail/{estateId}")]

        public async Task<IActionResult> GetEstateDetail(int estateId)
        {
            var estate = await _estateService.GetByIdAsync(estateId);
            return Ok(estate);
        }

        [HttpPost("AddEstatePhotos/{estateId}")]
        public async Task<IActionResult> AddEstatePhotos(int estateId, [FromForm] IFormFile image)
        {
            // Estate varlığının kontrolü
            var estate = await _estateService.GetByIdAsync(estateId);
            if (estate == null)
            {
                return NotFound($"Estate with ID {estateId} not found.");
            }

            if (image == null || image.Length == 0)
            {
                return BadRequest("No image provided.");
            }

            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            var estatePicture = new EstatePicture()
            {
                Estate = estate,
                EstateId = estateId,
                img = imageBytes
            };

            estate.EstatePictures.Add(estatePicture);
            await _estatePictureService.AddEstatePicture(estatePicture); 

            return Ok("Image added successfully.");
        }

    }
}

