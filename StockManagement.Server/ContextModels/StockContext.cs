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

        public StockContext(DbContextOptions<StockContext> options): base(options)
        {

        }
        
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
           
        }
    }

}

