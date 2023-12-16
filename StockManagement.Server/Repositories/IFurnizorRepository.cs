using StockManagement.Server.Entities;
using System.Collections.Generic;

namespace StockManagement.Server.Repositories
{
   public interface ISupplierRepository
   {
      Task<List<Supplier>> GetSuppliersAsync();
      Task<Supplier> GetSupplierAsync(int id);
      Task<Supplier> AddSupplierAsync(Supplier supplier);
      Task<Supplier> UpdateSupplierAsync(Supplier supplier);
      Task DeleteSupplierAsync(int id);
   }
}