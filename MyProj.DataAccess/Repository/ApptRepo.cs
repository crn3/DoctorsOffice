using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.Models.Models;
using MyProj.DataAccess.DataAccess;

namespace MyProj.DataAccess.Repository
{
	public class ApptRepo : Repository<Appointment>, IApptRepo
	{
		private readonly ProjDBContext _dbContext;
		public ApptRepo(ProjDBContext dbContext) :base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void Update(Appointment appt)
		{
			var apptFromDB = _dbContext.Appointments.
				FirstOrDefault(apptFromDB => apptFromDB.Id == appt.Id);
			apptFromDB.PPS = appt.PPS;
			apptFromDB.DoctorId = appt.DoctorId;
			apptFromDB.AppDate = appt.AppDate;
			apptFromDB.Notes = appt.Notes;
		}
	}
}
