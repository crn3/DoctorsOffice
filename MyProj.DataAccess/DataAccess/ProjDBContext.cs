using Microsoft.EntityFrameworkCore;
using MyProj.Models.Models;
using System.Collections.Generic;
using System;

namespace MyProj.DataAccess.DataAccess
{
	public class ProjDBContext : DbContext
	{
		public ProjDBContext(DbContextOptions<ProjDBContext> options) : base(options)
		{
		}
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
	}
}


