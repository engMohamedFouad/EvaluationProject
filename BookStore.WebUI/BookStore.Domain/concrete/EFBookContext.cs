using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.concrete
{
  public class EFBookContext:IbookReporisitory
    {
        EFDBcontext m = new EFDBcontext();
        public IEnumerable<Entities.Books> book
        {
            get {
                return m.book;
            }
        }
    }
}
