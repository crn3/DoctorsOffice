using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.DataAccess.Repository;

namespace MyProj.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepo PatientRepo { get; }
        void Save();
        IDoctorRepo DoctorRepo { get; }
        IApptRepo ApptRepo { get; }
    }
}
