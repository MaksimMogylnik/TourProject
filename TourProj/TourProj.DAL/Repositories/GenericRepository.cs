using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        DbSet<T> table;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public void CreateOrUpdate(T entity)
        {
            table.AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public T GetByOneIndex(int id)
        {
            return table.Find(id);
        }

        public T GetByTwoIndexes(int id1, int id2)
        {
            return table.Find(id1, id2);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
