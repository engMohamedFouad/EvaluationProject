using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Infrastructure.Binders
{
    public class CartV:IModelBinder
    {
         //that I make the session in seperate place better than make it in the codes 
        private const string sessionkey ="Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if(controllerContext.HttpContext.Session!=null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionkey];
            }
            if(cart==null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                   controllerContext.HttpContext.Session[sessionkey] = cart;
                }
            }
            return cart;
        }
    }
}