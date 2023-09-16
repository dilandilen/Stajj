using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAcces.Generic
{
    public class GenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public virtual void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                         ? context.Set<T>().ToList()
                         : context.Set<T>().Where(filter).ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault();
            }
        }


        public List<T> List()
        {
            using (var context = new TContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public virtual int GetCount(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return query.Count();
            }
        }
    }
}
