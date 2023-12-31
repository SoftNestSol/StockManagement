﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using StockManagement.Server.Entities;
using StockManagement.Server.ContextModels;
using System;
using StockManagement.Server.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace StockManagement.Server.ContextModels

{
    public class StockContext: IdentityDbContext <ApplicationUser>
    {
       
        public StockContext(DbContextOptions <StockContext> options):base(options)
        { 
        }
        
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductInOrder> ProductInOrder { get; set; }

        public DbSet<ProductInStock> ProductInStock { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


             modelBuilder.Entity<ApplicationUser>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.ApplicationUser)
            .HasForeignKey<ApplicationUser>(a => a.EmployeeId);

            modelBuilder.Entity<ProductInStock>()
       .HasKey(pis => new { pis.ProductId, pis.StockId }); 

            modelBuilder.Entity<ProductInStock>()
                .HasOne(pis => pis.Product)
                .WithMany(p => p.ProductInStock)
                .HasForeignKey(pis => pis.ProductId);

            modelBuilder.Entity<ProductInStock>()
                .HasOne(pis => pis.Stock)
                .WithMany(s => s.ProductInStock)
                .HasForeignKey(pis => pis.StockId);

            modelBuilder.Entity<ProductInOrder>()
                .HasKey(pio => new { pio.ProductId, pio.OrderId }); 

            modelBuilder.Entity<ProductInOrder>()
                .HasOne(pio => pio.Product)
                .WithMany(p => p.ProductInOrder)
                .HasForeignKey(pio => pio.ProductId);

            modelBuilder.Entity<ProductInOrder>()
                .HasOne(pio => pio.Order)
                .WithMany(o => o.ProductInOrder)
                .HasForeignKey(pio => pio.OrderId);

        }
        

    }

}

