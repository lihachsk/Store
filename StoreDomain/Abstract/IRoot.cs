using StoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDomain.Abstract
{
    public interface IRoot
    {
        IRepository<Book> Books { get; }
    }
}
