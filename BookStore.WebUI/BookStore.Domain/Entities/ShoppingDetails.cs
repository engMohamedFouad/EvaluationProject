using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
   public class ShoppingDetails
    {
       [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage="please enter your name ")]
       public string Name { get; set; }
         [Required(ErrorMessage = "please enter the Required Field ")]
        public string Line1 { get; set; }
         public string Line2 { get; set; }
        [Required(ErrorMessage = "please enter Your City ")]
        public string City { get; set; }
        [Required(ErrorMessage = "please enter Your State ")]
        public string State { get; set; }//that to describe the place specifical
        [Required(ErrorMessage = "please enter Your Country ")]
        public string Country { get; set; }
        public bool Giftwrap { get; set; }
    }
}
