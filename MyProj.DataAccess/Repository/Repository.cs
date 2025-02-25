using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProj.DataAccess.DataAccess;

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

        public T? Get(string id)
        {
            if (id == null)
                return null;
            else
                return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> list = dbSet;
            return list.ToList();
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }
    }
}
