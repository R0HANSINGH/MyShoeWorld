using Microsoft.EntityFrameworkCore;
using MyShoeWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoeWorld.Dal
{
    public class MyShoeWorldDbContext : DbContext
    {
        public MyShoeWorldDbContext()
        {

        }
        public MyShoeWorldDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PREDATOR\\SQLEXPRESS;" +
                "Initial Catalog=MyShoeWorldDb;Trusted_Connection=true;TrustServerCertificate=True;");
        }
    }
}
