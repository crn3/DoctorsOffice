using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.Models.Models
{
	public class Doctor
	{
		[Key]
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Specialisation { get; set; }
		public List<Appointment>? Appointments { get; set; }
		public string? Image { get; set; }
	}
}