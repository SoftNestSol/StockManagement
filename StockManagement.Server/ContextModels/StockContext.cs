using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using StockManagement.Server.Entities;
using StockManagement.Server.ContextModels;
using System;





namespace StockManagement.Server.ContextModels

{
    public class StockContext:DbContext
    {

        public StockContext(DbContextOptions<StockContext> options): base(GetOptions())
        {
        }
        
        
       public DbSet<Product> Products { get; set; }
    public DbSet<ProductInOrder> ProductsInOrders { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<ProductInStock> ProductsInStocks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInOrder>()
                .HasKey(pio => new { pio.OrderId, pio.ProductId });

            modelBuilder.Entity<ProductInStock>()
                .HasKey(pis => new { pis.StockId, pis.ProductId });
           
        }
    }

}

