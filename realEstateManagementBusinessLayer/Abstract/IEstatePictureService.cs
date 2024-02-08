using System;
using realEstateManagementEntities.Models;

namespace realEstateManagementBusinessLayer.Abstract
{
	public interface IEstatePictureService
	{
        Task<EstatePicture> AddEstate(EstatePicture estatePicture);
        Task Delete(EstatePicture estate);
    }
}