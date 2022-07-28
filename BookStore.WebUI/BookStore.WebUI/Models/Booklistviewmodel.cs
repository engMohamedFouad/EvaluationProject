using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class Booklistviewmodel
    {
        public IEnumerable<Books> book { get; set; }
        //if i want it only to get the data then I will write get only but if i want to update the data then but set,get.
        public PagingInfo pageinfo { get; set; }
        public string CurrentSpecification { get; set; }
    }
}