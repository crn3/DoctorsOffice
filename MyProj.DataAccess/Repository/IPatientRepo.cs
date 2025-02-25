using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProj.Models.Models;

namespace MyProj.DataAccess.Repository
{
    public interface IPatientRepo : IRepository<Patient>
    {
        public void Update(Patient patient);
    }
}
