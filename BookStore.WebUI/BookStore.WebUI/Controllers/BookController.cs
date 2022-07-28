using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.concrete;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    { 
        // GET: Book
        EFBookContext m = new EFBookContext();
        private int pagesize = 3;
        public ViewResult list()
        { 
            return View(m.book);
        }
        public ViewResult listAll(string specification, int page = 1)
        {
            // pigenation idea  that I want to make the page take limited number of elements and the other take else.
            Booklistviewmodel listview = new Booklistviewmodel
            {
                book = m.book
                         .Where(b=>specification==null||b.specification==specification)
                         .OrderBy(b => b.ISBN)
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize),
                pageinfo = new Models.PagingInfo
                {
                    currentpage = page,
                    itemperpage = pagesize,
                    totalItem =specification==null?m.book.Count():m.book.Where(b=>b.specification==specification).Count()
                    //if there are specification then count will be for the specification only not at all the book item .
                },
                CurrentSpecification= specification
            };
            return View(listview);

            // the past way
               //return View(m.book
               //.OrderBy(b =>b.ISBN) 
               // .Skip((page-1)*pagesize)
               // .Take(pagesize)
               // );
        }
    }
}