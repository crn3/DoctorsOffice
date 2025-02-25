using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(object id);  //object instead of explicitly an int or string
                           //patient uses a string, appt/dr uses an int
    }
}
