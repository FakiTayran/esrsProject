using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace realEstateManagement.Data
{
	public class AdminUser : IdentityUser
    {
		public required string Name { get; set; }

		public required string Surname { get; set; }

        public string? Token { get; set; }

    }
}

