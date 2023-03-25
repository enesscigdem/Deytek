using System;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // bağlantı stringimizi tanımlayacağız
            optionsBuilder.UseSqlServer("server=localhost;uid=sa;password=reallyStrongPwd123;database=DeytekDb;TrustServerCertificate=true;");
        }
    }
}

