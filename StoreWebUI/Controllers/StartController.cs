using StoreDomain.Abstract;
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
        public StartController(IRoot _root)
        {
            root = _root;
        }
        public ActionResult Page()
        {
            return View(root.Books.Get());
        }
    }
}