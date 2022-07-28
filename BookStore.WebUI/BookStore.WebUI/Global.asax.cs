using BookStore.Domain.Entities;
using BookStore.WebUI.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {// that where i execute anything under HttpContext such as Session.
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartV());
            // that where I make the session execute when the app is start and I bind the session with the Global page.
            // the ModelBinders that I make it take custom binder is CartV instead of the executed Binder.
        }
    }
}
