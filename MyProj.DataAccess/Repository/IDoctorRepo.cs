using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.Models.Models;

namespace MyProj.DataAccess.Repository
{
	public interface IDoctorRepo : IRepository<Doctor>
	{
		public void Update(Doctor doctor);
	}
}
