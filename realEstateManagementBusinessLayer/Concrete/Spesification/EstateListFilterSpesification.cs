using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using realEstateManagement.Data;
using realEstateManagementEntities.Models;

namespace realEstateManagementBusinessLayer.Concrete.Spesification
{
    public class EstateFilterSpesification : Specification<Estate>
    {
        //public EstateFilterSpesification(int numberOfRooms, string? city, string? postcode, string searchContent,PropertyType PR)
        //{
        //    if (time != null && (time.Contains("Giorno") || time.Contains("Mese") || time.Contains("Gün") || time.Contains("Ay")))
        //    {
        //        time = null;
        //    }


        //    if (type != null && (type == "Hepsi" || type == "Tutte"))
        //    {
        //        type = null;
        //    }
        //    if (jsonLanguage == null)
        //    {
        //        jsonLanguage = "#it";
        //    }
        //    Query.Where(x => (x.OwnerId == userId && x.Language == jsonLanguage) && (string.IsNullOrEmpty(type) || x.Category == type) && (string.IsNullOrEmpty(time) || x.Time == time) && (!(searchContent != null) || x.Id.ToString().Contains(searchContent) || x.Category.ToLower().Contains(searchContent) || x.Time.ToLower().Contains(searchContent) || x.Description.ToLower().Contains(searchContent)));
        //}
    }
}

