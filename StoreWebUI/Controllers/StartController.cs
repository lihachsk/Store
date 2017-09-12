using StoreDomain.Abstract;
using StoreDomain.Entities;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Controllers
{
    public class StartController : Controller
    {
        private IRoot root { get; set; }
        public int pageSize = 4;
        public StartController(IRoot _root)
        {
            root = _root;
        }
        public ViewResult Page(string genre, int page = 1)
        {
            BookPageInfo bookPageInfo = new BookPageInfo()
            {
                Books = GetBooksByPage(genre, page),

                CurrentGenre = genre,
                CurrentPage = page
            };
            bookPageInfo.TotalBooks = root.Books.GetQ().Count();
            bookPageInfo.TotalPages = bookPageInfo.TotalBooks / pageSize + (bookPageInfo.TotalBooks % pageSize > 0 ? 1 : 0);
            return View(bookPageInfo);
        }
        [HttpGet]
        public ActionResult _Books(string genre, int page = 1)
        {
            return PartialView("_Books", GetBooksByPage(genre, page));
        }
        private List<Book> GetBooksByPage(string genre, int page = 1)
        {
            return root.Books
                            .GetQ()
                            .Where(x => genre == null || x.Genre == genre)
                            .OrderBy(x => x.Id)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize).ToList();
        }
    }
}