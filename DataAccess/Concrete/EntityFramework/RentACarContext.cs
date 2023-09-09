using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class RentACarContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = RentACarDB; User Id = SA; Password = rentacardb;; TrustServerCertificate=true");

        }

        public DbSet<Car> cars { get; set; }

        
    }
}


