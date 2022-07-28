using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.WebUI.Models
{
    public class PagingInfo
    {
        public int currentpage { get; set; }
        public int totalItem { get; set; }
        public int itemperpage { get; set; }
        public int totalpage { get { return (int)Math.Ceiling((decimal)totalItem / itemperpage); } }
    }
}