using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class CartIndexViewModel//that for display the cart.
    {
        public Cart cart { get; set; }// the cart is contain of set of books and quantity so that for display the books
        public string ReturnUrl { get; set; }//that for the button of back to select from the menu of books
    }
}