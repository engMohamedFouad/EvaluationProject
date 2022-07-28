using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.WebUI.Controllers;
using BookStore.Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        { 
            //arrange
            Books book = new Books { ISBN = 1, title = "b1" };
            Books b2 = new Books { ISBN = 2, title = "b2" };
            //act
            Cart c = new Cart();
            c.additem(book);
            c.additem(b2, 3);
            //in the case of there are aleast of another class
            cartline[] target = c.lines.ToArray();
            //assert
            Assert.AreEqual(target[0].Book,book);

        }
        // to test capality to add quantity or not.
        [TestMethod]
        public void Add_quantity_ofitems()
        {
            //arrange
            Books book = new Books { ISBN = 1, title = "b1" };
            Books b2 = new Books { ISBN = 2, title = "b2" };
            //act
            Cart c = new Cart();
            c.additem(book);
            c.additem(b2, 3);
            c.additem(book, 2);
            cartline[] target = c.lines.ToArray();
            //assert
            Assert.AreEqual(target.Length, 2);
            Assert.AreEqual(target[0].Quantity,3);
        }

        [TestMethod]
        public void remove_item_ofitems()
        {
            //arrange
            Books book = new Books { ISBN = 1, title = "b1" };
            Books b2 = new Books { ISBN = 2, title = "b2" };
            //act
            Cart c = new Cart();
            c.additem(book);
            c.additem(b2, 3);
            c.additem(book, 2);
            c.removeitem(b2);
            //assert
            Assert.AreEqual(c.lines.Where(cl =>cl.Book==b2).Count(), 0);
        }
        [TestMethod]
        public void can_compute_item()
        {
            //arrange
            Books book = new Books { ISBN = 1, title = "b1",Price=50 };
            Books b2 = new Books { ISBN = 2, title = "b2",Price=40 };
            //act
            Cart c = new Cart();
            c.additem(book);
            c.additem(b2, 3);
            c.additem(book, 2);
            var result1=c.computeitem();
            //assert
            Assert.AreEqual(result1,270);
        }
        [TestMethod]
        public void can_clear_items()
        {
            //arrange
            Books book = new Books { ISBN = 1, title = "b1", Price = 50 };
            Books b2 = new Books { ISBN = 2, title = "b2", Price = 40 };
            //act
            Cart c = new Cart();
            c.additem(book);
            c.additem(b2, 3);
            c.additem(book, 2);
            c.clear();
            cartline[] target = c.lines.ToArray();
            //assert
             Assert.AreEqual(target.Length, 0);
        }
        [TestMethod]
        public void addtoitems()
        {
            //arrange
            Books book = new Books { ISBN = 1, title = "b1", Price = 50 };
            //act
            Cart c = new Cart();
            c.additem(book);
           CartController m = new CartController();
           m.addtocart(c, 1,null);
            //there are a conflict in versions that statement is wrong it need system.web Version  4.0.0.0 so it's not executed.
           RedirectToRouteResult result= m.addtocart(c,2,"myl");
            //assert
           //Assert.AreEqual(result.RouteValues,"index");
        }
    }
}
