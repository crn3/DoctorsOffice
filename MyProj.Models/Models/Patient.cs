﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProj.Models.Models
{
	public class Patient : IValidatableObject
	{
		[Key]
		public string PPS { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime DOB { get; set; }
		[Required]
		public string Gender { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public List<Appointment>? Appointments { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (string.IsNullOrWhiteSpace(Phone) && string.IsNullOrWhiteSpace(Email))
			{
				yield return new ValidationResult(
					"At least one contact option is required.");
			}
		}
	}
}
