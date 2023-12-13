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
       
        public StockContext(DbContextOptions <StockContext> options):base(options)
        { 
        }
        
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Produs_in_stoc>()
        .HasKey(pis => new { pis.Produs_id, pis.Stoc_id }); // Composite key

    modelBuilder.Entity<Produs_in_stoc>()
        .HasOne<Produs>(pis => pis.Produs)
        .WithMany(p => p.Produs_in_stoc)
        .HasForeignKey(pis => pis.Produs_id);

    modelBuilder.Entity<Produs_in_stoc>()
        .HasOne<Stoc>(pis => pis.Stoc)
        .WithMany(s => s.Produs_in_stoc)
        .HasForeignKey(pis => pis.Stoc_id);

    // Configure the many-to-many relationship between Produs and Comanda
    modelBuilder.Entity<Produs_in_comanda>()
        .HasKey(pic => new { pic.Comanda_id, pic.Produs_id }); // Composite key

    modelBuilder.Entity<Produs_in_comanda>()
        .HasOne<Produs>(pic => pic.Produs)
        .WithMany(p => p.Produs_in_comanda)
        .HasForeignKey(pic => pic.Produs_id);

    modelBuilder.Entity<Produs_in_comanda>()
        .HasOne<Comanda>(pic => pic.Comanda)
        .WithMany(c => c.Produs_in_comanda)
        .HasForeignKey(pic => pic.Comanda_id);
        
        }
        

    }

}

