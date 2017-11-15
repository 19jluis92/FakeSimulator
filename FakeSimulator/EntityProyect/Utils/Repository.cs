using EntityProject.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private EntitiesContext context;
        public Repository(EntitiesContext context){
            this.context = context;
        }

        public DbSet<T> Table { get { return context.Set<T>(); } }

        public void Attach(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public T Get(long id)
        {
            return Table.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public void Insert(T entity)
        {
            Table.Add(entity);
        }

        public void SubmitChanges()
        {
            context.SaveChanges();
        }
    }
}
