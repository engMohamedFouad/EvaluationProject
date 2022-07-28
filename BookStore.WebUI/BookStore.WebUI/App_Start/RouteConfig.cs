using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null, "", new {Controller="Book",Action="listAll",specification=(string)null,page=1
                }
                );
            // if he write BookListPage{page} then he will execute the under cases and the default page is 1
            //that i only put the ways of receive the data from user can enter it
            routes.MapRoute(
              null, "BookListPage{page}", new
              {
                  Controller = "Book",
                  Action = "listAll",
                  specification = (string)null,
              }
              , new {page=@"\d+" }//I put the condition that the number should be one byte and more.
              );
            routes.MapRoute(
              null, "page{page}", new
              {
                  Controller = "Book",
                  Action = "listAll",
                  specification = (string)null,
              }
              , new { page = @"\d+" }
              );
            routes.MapRoute(
               null, "{specification}", new
               {
                   Controller = "Book",
                   Action = "listAll",
                   page = 1
               }
               );
            routes.MapRoute(
               null, "{specification}/page{page}", new
               {
                   Controller = "Book",
                   Action = "listAll",
               }
               , new { page = @"\d+" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "listAll", id = UrlParameter.Optional }
            );
        }
    }
}
