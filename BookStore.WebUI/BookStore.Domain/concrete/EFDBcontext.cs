using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.Domain.concrete
{
   public class EFDBcontext:DbContext
    {
       public DbSet<Books> book { get; set; }
    }
}
