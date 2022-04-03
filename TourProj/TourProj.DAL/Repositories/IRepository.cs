using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProj.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetByOneIndex(int id);
        T GetByTwoIndexes(int id1, int id2);
        IEnumerable<T> GetAll();
        void CreateOrUpdate(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
