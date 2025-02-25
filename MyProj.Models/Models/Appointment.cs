using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.Models.Models
{
	public class Appointment
	{
		[Key]
		public int Id { get; set; }
		//foreign key to link to patient table
		[ForeignKey("Patient")] //need to tell ef core that this is the foreign key
								//panics and creates a whole new column 'PatientPPS' otherwise
		[Required]
		public string PPS { get; set; }
		public Patient Patient { get; set; }
        //foreign key to link to doctor table
        [Required] 
		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }

        [Required] 
		public DateTime AppDate { get; set; }

		public string? Notes { get; set; }
	}
}
