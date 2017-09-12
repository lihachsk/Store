using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreDomain.Abstract;
using StoreDomain.Entities;
using System.Collections.Generic;
using StoreWebUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace StoreTests
{
    [TestClass]
    public class StartTestController
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IRoot> mock = new Mock<IRoot>();
            mock.Setup(m => m.Books.Get()).Returns(new List<Book>
            {
                new Book{ Id = new Guid("03f30616-9eed-43dd-9d73-6741d188aa31"), Name = "Book1"},
                new Book{ Id = new Guid("03f30616-9eed-43dd-9d73-6741d188aa32"), Name = "Book2"},
                new Book{ Id = new Guid("03f30616-9eed-43dd-9d73-6741d188aa33"), Name = "Book3"},
                new Book{ Id = new Guid("03f30616-9eed-43dd-9d73-6741d188aa34"), Name = "Book4"},
                new Book{ Id = new Guid("03f30616-9eed-43dd-9d73-6741d188aa35"), Name = "Book5"}
            });
            StartController controller = new StartController(mock.Object);
            controller.pageSize = 3;
            IEnumerable<Book> result = (IEnumerable<Book>)controller.Page(2).Model;
            List<Book> Books = result.ToList();
            Assert.IsTrue(Books.Count == 2);
            Assert.AreEqual(Books[0].Name, "Book4");
            Assert.AreEqual(Books[1].Name, "Book5");
        }

    }
}
