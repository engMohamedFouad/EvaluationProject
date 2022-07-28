using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class Cart
    {
       // all thee code is for the book part and the check and adding the book of website that in cartcontroller
        private List<cartline> linecollection = new List<cartline>();
        public void additem(Books book,int quantity=1)
        {
            cartline line = linecollection
                .Where(b =>b.Book.ISBN==book.ISBN)
                .FirstOrDefault();
            if (line == null)
            {
                linecollection.Add(new cartline { Book = book, Quantity = quantity });
            }
            else line.Quantity += quantity;
        }// the end of method of adding  
        // the linecollection that where i store all items that selected by the user.
        public void removeitem(Books book)
        {
            linecollection.RemoveAll(b => b.Book.ISBN == book.ISBN);
        }// the end of remove

        public decimal computeitem()
        {
            return linecollection.Sum(b => b.Book.Price * b.Quantity);
        }// to sum the collection of items 
        
        public void clear()
        {
            linecollection.Clear();
        }// to remove all items 
        public IEnumerable<cartline> lines
        {
            get { return linecollection; }
        }// that to return all the item that user selected.
    }
    public class cartline
    {
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}
