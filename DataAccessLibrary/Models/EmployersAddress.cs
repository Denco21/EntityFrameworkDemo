using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class EmployersAddress
	{

		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string StreetAddress { get; set; }

		[Required]
		[MaxLength(15)]
		public string City { get; set; }

		[Required]
		[MaxLength(15)]
		public string State { get; set; }

		[Required]
		[MaxLength(10)]
		public string ZipCode { get; set; }

		[Required]
		[MaxLength(100)]
		[Column(TypeName = "nvarchar(100)")]
		public string? Addresses { get; set; } = null;

		[Required]
		[MaxLength(15)]
        public string  CompanyName { get; set; } 


    }
}
