using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStoreAPI.Models
{
    public class GroceryStoreContext : DbContext
    {
        public GroceryStoreContext()
        {
        }

        public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
