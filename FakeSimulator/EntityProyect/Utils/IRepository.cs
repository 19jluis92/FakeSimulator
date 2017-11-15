using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
    public interface IRepository
    {
        object Get(long id);
        void Attach(object entity);
        IQueryable<object> GetAll();
        void Insert(object entity);
        void Delete(object entity);
        void SubmitChanges();
    }
    public interface IRepository<T>:  IDisposable where T : EntityBase
    {
        T Get(long id);
        void Attach(T entity);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void SubmitChanges();
    }
}
