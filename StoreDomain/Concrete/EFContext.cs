using StoreDomain.Abstract;
using StoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDomain.Concrete
{
    public class EFContext : DbContext, IContext
    {
        public EFContext() : base("Store") { }
        public DbSet<Book> Books { get; set; }
    }
}
