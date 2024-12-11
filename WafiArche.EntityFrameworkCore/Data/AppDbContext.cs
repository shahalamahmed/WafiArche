using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Domain.Categories;
using WafiArche.Domain.Customers;
using WafiArche.Domain.Employees;
using WafiArche.Domain.OrderDetails;
using WafiArche.Domain.Orders;
using WafiArche.Domain.Products;
using WafiArche.Domain.Shippers;
using WafiArche.Domain.Suppliers;

namespace WafiArche.EntityFrameworkCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Shipper> Shippers { get; set; } 
        public DbSet<Order> Orders{ get; set; } 
        public DbSet<OrderDetail> OrderDetails{ get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
