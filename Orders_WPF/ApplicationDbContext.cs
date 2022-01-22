using System;
using System.Data.Entity;
using System.Linq;

namespace Orders_WPF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }


    }


}