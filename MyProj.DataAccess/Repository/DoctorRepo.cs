using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.Models.Models;
using MyProj.DataAccess.DataAccess;

namespace MyProj.DataAccess.Repository
{
	public class DoctorRepo : Repository<Doctor>, IDoctorRepo
	{
		private readonly ProjDBContext _dbContext;
		public DoctorRepo(ProjDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Doctor doctor)
		{
			var doctorFromDB = _dbContext.Doctors.
				FirstOrDefault(doctorFromDB => doctorFromDB.ID == doctor.ID);
			doctorFromDB.FirstName = doctor.FirstName;
			doctorFromDB.LastName = doctor.LastName;
			doctorFromDB.Specialisation = doctor.Specialisation;
			if(doctor.Image != null)
			{
				doctorFromDB.Image = doctor.Image;
			}
		}
	//	public Doctor Get(int ID)
	//	{
	//		throw new NotImplementedException();
	//	}
	}
}
