using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using realEstateManagementEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace realEstateManagementDataLayer.EntityFramework
{
	public class RealEstateManagementDbContext : IdentityDbContext<AdminUser>
    {
        public RealEstateManagementDbContext(DbContextOptions<RealEstateManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstatePicture> EstatePictures { get; set; }

    }
}



