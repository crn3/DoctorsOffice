using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;

namespace MyProj.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjDBContext _dbContext;
        public IPatientRepo PatientRepo { get; private set; }
        public IDoctorRepo DoctorRepo { get; private set; }
        public IApptRepo ApptRepo { get; private set; }
        public UnitOfWork(ProjDBContext projDBContext)
        {
            _dbContext = projDBContext;
            PatientRepo = new PatientRepo(_dbContext);
            DoctorRepo = new DoctorRepo(_dbContext);
            ApptRepo = new ApptRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
