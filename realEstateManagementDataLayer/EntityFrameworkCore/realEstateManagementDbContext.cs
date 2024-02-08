using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using realEstateManagement.Data;
using realEstateManagementEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace realEstateManagementDataLayer.EntityFramework
{
	public class realEstateManagementDbContext : IdentityDbContext<AdminUser>
    {
        public realEstateManagementDbContext(DbContextOptions<realEstateManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstatePicture> EstatePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}



