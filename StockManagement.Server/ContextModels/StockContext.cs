using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



namespace StockManagement.Server.ContextModels

{
    public class StockContext:DbContext
    {
        public StockContext(DbContextOptions<StockContext> options): base(options)
        {
        }

        public DbSet<Produs> Produs { get; set; }
        public DbSet<ProdusInStoc> ProduseInStoc { get; set; }
        public DbSet<Stoc> Stoc { get; set; }
        public DbSet<ProdusInComanda> ProduseInComanda { get; set; }
        public DbSet<Comanda> Comeanda { get; set; }
        public DbSet<Furnizor> Furnizor { get; set; }
        public DbSet<Angajat> Angajat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Produs>().HasKey(p => p.ProdusId);
            modelBuilder.Entity<ProdusInStoc>().HasKey(p => new { p.StocId, p.ProdusId });
            modelBuilder.Entity<Stoc>().HasKey(s => s.StocId);
            modelBuilder.Entity<ProdusInComanda>().HasKey(p => new { p.ComandaId, p.ProdusId });
            modelBuilder.Entity<Comanda>().HasKey(c => c.ComandaId);
            modelBuilder.Entity<Furnizor>().HasKey(f => f.FurnizorId);
            modelBuilder.Entity<Angajat>().HasKey(a => a.AngajatId);

           
            modelBuilder.Entity<ProdusInStoc>()
                .HasOne(pis => pis.Produs)
                .WithMany() 
                .HasForeignKey(pis => pis.ProdusId);

            modelBuilder.Entity<ProdusInStoc>()
                .HasOne(pis => pis.Stoc)
                .WithMany() 
                .HasForeignKey(pis => pis.StocId);

            modelBuilder.Entity<ProdusInComanda>()
                .HasOne(pic => pic.Produs)
                .WithMany() 
                .HasForeignKey(pic => pic.ProdusId);

            modelBuilder.Entity<ProdusInComanda>()
                .HasOne(pic => pic.Comanda)
                .WithMany()
                .HasForeignKey(pic => pic.ComandaId);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Furnizor)
                .WithMany() 
                .HasForeignKey(c => c.FurnizorId);

            modelBuilder.Entity<Comanda>()
                .HasOne(c => c.Angajat)
                .WithMany() 
                .HasForeignKey(c => c.AngajatId);

           
        }
    }

}

