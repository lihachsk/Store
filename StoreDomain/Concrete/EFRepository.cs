using StoreDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDomain.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        IContext context;
        private DbSet<T> dbSet { get; set; }
        public void SetContext(IContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public T Find(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<T> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IQueryable<T> GetQ()
        {
            return dbSet;
        }

        public bool Any(Func<T, bool> predicate)
        {
            return dbSet.Any<T>(predicate);
        }

        public void Remove(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
            dbSet.RemoveRange(items);
        }

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
