using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class Books
    {
        [Key]
        public int ISBN { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string specification { get; set; }
    }
}
