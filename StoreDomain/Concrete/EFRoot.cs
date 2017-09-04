using StoreDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDomain.Entities;

namespace StoreDomain.Concrete
{
    public class EFRoot : IRoot
    {
        private IContext context;
        public EFRoot(IContext _context
                     ,IRepository<Book> _book)
        {
            context = _context;
            Books = _book;
            Books.SetContext(context);
        }
        public IRepository<Book> Books { get; set; }
    }
}
