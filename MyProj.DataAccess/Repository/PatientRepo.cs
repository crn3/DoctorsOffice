using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;

namespace MyProj.DataAccess.Repository
{
    public class PatientRepo : Repository<Patient>, IPatientRepo
    {
        private readonly ProjDBContext _dbContext;
        public PatientRepo(ProjDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Patient Get(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Patient patient)
        {
            var patientFromDB = _dbContext.Patients.
                FirstOrDefault(patientFromDB => patientFromDB.PPS == patient.PPS);
            patientFromDB.FirstName = patient.FirstName;
            patientFromDB.LastName = patient.LastName;
            patientFromDB.DOB = patient.DOB;
            patientFromDB.Gender = patient.Gender;
            patientFromDB.Phone = patient.Phone;
            patientFromDB.Address = patient.Address;
            patientFromDB.Email = patient.Email;
        }
        public void Add(Patient patient)
        {
            _dbContext.Patients.Add(patient);
        }
    }
}
