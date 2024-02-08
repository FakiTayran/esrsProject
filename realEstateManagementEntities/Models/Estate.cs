using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using realEstateManagement.Data;

namespace realEstateManagementEntities.Models
{
    public class Estate : BaseEntity
    {
        [Required]
        [Display(Name = "Property Type")]

        public EstateType EstateType { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Number Of Rooms")]

        public int NumberOfRooms { get; set; }

        public virtual ICollection<EstatePicture>? EstatePictures { get; set; }

        public required string City { get; set; }

        public required string PostCode { get; set; }

        public required string Description { get; set; }

        public required string Headline  { get; set; }

        public PropertyType PropertyType { get; set; }

        public AdminUser? EstateAgent { get; set; }

    }

    public enum EstateType
    {
        [Display(Name = "For Sale")]
        ForSale = 0,
        [Display(Name = "For Rent")]
        ForRent = 1,
        [Display(Name = "Daily Rent")]
        DailyRent = 2
    }

    public enum PropertyType
    {
        [Display(Name = "Apartment")]
        Apartment = 0,
        [Display(Name = "Villa")]
        Villa = 1,
        [Display(Name = "Home")]
        Home = 2,
        [Display(Name = "Office")]
        Office = 3,
        [Display(Name = "Building")]
        Building = 4,
        [Display(Name = "TownHouse")]
        TownHouse = 5,
        [Display(Name = "Shop")]
        Shop = 6,
        [Display(Name = "Garage")]
        Garage = 7

    }


}

