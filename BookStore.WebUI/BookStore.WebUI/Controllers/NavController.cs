using BookStore.Domain.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        EFDBcontext v = new EFDBcontext();
        public PartialViewResult Menu(string specification=null)
        {
            ViewBag.selectedspec = specification;
            IEnumerable<string> spec = v.book.Select(b => b.specification).Distinct();
            return PartialView(spec);
        }
    }
}