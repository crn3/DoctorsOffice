using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
	public interface IApptRepo : IRepository<Appointment>
	{
		public void Update(Appointment appt);
        IEnumerable<Appointment> GetAll(string? includeProperties = null); // Add this
    }
}
