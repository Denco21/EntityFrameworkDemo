using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class HomeAddress
	{
		public int Id { get; set; }

		public string StreetAddress { get; set; } 

		public string City { get; set; }

		public string State { get; set; }

		public string ZipCode { get; set; }

		[Required]
		[MaxLength(100)]
		[Column(TypeName = "nvarchar(100)")]
		public string? Addresses { get; set; } 
	}
}
