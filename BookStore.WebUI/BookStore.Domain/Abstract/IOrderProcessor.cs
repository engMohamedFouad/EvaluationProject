using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
    interface IOrderProcessor
    {
        void processorder(Cart cart, ShoppingDetails shoppingdetails);
       //that to make the session of products that selected for the data that customer enter in the shopping details.
        // and the implement of it that send mail to the users that will appear in class EmailServic in concrete folder.
    }
}
