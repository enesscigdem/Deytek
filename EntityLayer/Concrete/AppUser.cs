using System;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
	public class AppUser : IdentityUser
	{
        public string NameSurname { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}

