using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProj.DataAccess.DataAccess;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyProj.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProjDBContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(ProjDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }

        public T? Get(object id) //generic object to allow string(pps) and ints (appt & doctor ids)
        {
            if (id == null)
                return null;
            else
                return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> list = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    list = list.Include(includeProp);
                }
            }
            return list.ToList();
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
