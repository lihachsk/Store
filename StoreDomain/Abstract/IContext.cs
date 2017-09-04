using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StoreDomain.Entities;

namespace StoreDomain.Abstract
{
    public interface IContext
    {
        DbSet<Book> Books { get; set; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        void Dispose();
    }
}
