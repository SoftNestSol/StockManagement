using StockManagement.Server.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;

namespace StockManagement.Server.Repositories
{
   public class SupplierRepository : ISupplierRepository
   {
      private readonly StockContext _context;

      public SupplierRepository(StockContext context)
      {
         _context = context;
      }

      public async Task<List<Supplier>> GetSuppliersAsync()
      {
         return await _context.Suppliers.ToListAsync();
      }

      public async Task<Supplier> GetSupplierAsync(int id)
      {
         return await _context.Suppliers.FindAsync(id);
      }

      public async Task<Supplier> AddSupplierAsync(Supplier supplier)
      {
         _context.Suppliers.Add(supplier);
         await _context.SaveChangesAsync();
         return supplier;
      }

      public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
      {
         _context.Entry(supplier).State = EntityState.Modified;
         await _context.SaveChangesAsync();
         return supplier;
      }

      public async Task DeleteSupplierAsync(int id)
      {
         var supplier = await _context.Suppliers.FindAsync(id);
         _context.Suppliers.Remove(supplier);
         await _context.SaveChangesAsync();
      }
   }
}