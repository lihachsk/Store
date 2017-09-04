using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDomain.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T item);
        T Find(Guid Id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        IQueryable<T> GetQ();
        bool Any(Func<T, bool> predicate);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
        void Update(T item);
        void SetContext(IContext _context);
    }
}
