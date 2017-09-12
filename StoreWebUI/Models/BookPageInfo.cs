using StoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWebUI.Models
{
    public class BookPageInfo
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentGenre { get; set; }
        public int CurrentPage { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPages { get; set; }
    }
}