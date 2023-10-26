using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class PeopleContext : DbContext	
	{


		public DbSet<People> Peoples { get; set; }

		public DbSet<HomeAddress> Addresses { get; set; } 

		public DbSet<EmployersAddress> Employers { get; set; } 



		protected override void OnConfiguring(DbContextOptionsBuilder options)

		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var config = builder.Build();
			options.UseSqlServer(config.GetConnectionString("Default"));



		}
	}
}
