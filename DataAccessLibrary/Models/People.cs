using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class People
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }
		public List<HomeAddress> HomeAddresses { get; set; } = new List<HomeAddress>(); 

		public List<EmployersAddress> Employers { get; set; } = new List<EmployersAddress>();


	}
}
