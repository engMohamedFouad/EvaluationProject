using BookStore.Domain.concrete;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //private const string sessionKey = "Cart";
        EFBookContext x = new EFBookContext();

        public ActionResult Index(Cart cart, string url)// that for display the cart that where the items selected by user,where you make operation that send the url to display(index) that will receive it in the parameter .
        {
            return View(new CartIndexViewModel { cart = cart, ReturnUrl = url });
        }
        public RedirectToRouteResult addtocart(Cart cart, int ISBN, string returnURL)//the name of parameters should be such as the fields you send them as hidden
            
            //that check the number of item with the number of item in database and return at this adding url that is store for the book.
        {
            // you reseive the book that name book and check the isbn that equal the isbn that the site give or not. and that every book have url that after adding the item that the url is saved that when yo want to back again to the place where you choose it you can do that.
            Books book = x.book.FirstOrDefault(b => b.ISBN == ISBN);
            if(book!=null)
            {
                cart.additem(book);// i can take list of cartline and make the operation rather than make the class of cart.
            }
            return RedirectToAction("Index", new { returnURL });// that will go to the page of display item and send the url that to back again.
        }
        public RedirectToRouteResult RemovetoCart(Cart cart,int isbn, string returnURL)// that for remove item 
        {
            Books book = x.book.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                cart.removeitem(book);
            }
            return RedirectToAction("Index", new { returnURL });
        }
        //private Domain.Entities.Cart Getvalue()
        //{
        //    Cart cart = (Cart)Session[sessionKey];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session[sessionKey] = cart;
        //    }
        //    return cart;
        //}
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView("Summary", cart);
        }
        public ViewResult Check()
        {
            if (ModelState.IsValid)
            { return View(); }
             // send object from shopping cart to the page of check
            else
            {
                return View();
            }
        }
    }
}