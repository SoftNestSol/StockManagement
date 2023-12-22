using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace StockManagement.Server.Repositories
{
    public class ProductInStockRepository : IProductInStockRepository
    {
        public readonly StockContext _stockContext;

        public ProductInStockRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public async Task<ProductInStock> AddProductInStockAsync(ProductInStock ProductInStock)
        {
            _stockContext.ProductInStock.Add(ProductInStock);
            return ProductInStock;

            
        }

        public async Task DeleteProductInStockAsync(int ProdusId, int StocId)
        {

            var ProductInStock = await _stockContext.ProductInStock.FindAsync(ProdusId, StocId);

                if (ProductInStock != null)
                {
                    _stockContext.ProductInStock.Remove(ProductInStock);

                    await _stockContext.SaveChangesAsync();
                }
        }

        public async Task<ProductInStock> GetProductInStockAsync(int ProdusId,int StocId)
        {
            var ProductInStocks = await _stockContext.ProductInStock.FindAsync(ProdusId,StocId);
            return ProductInStocks;
        }

        public async Task<List<ProductInStock>> GetProductInStocksAsync()
        {
            var ProductInStocks = await _stockContext.ProductInStock.ToListAsync();
            return ProductInStocks;
        }

        public async Task<ProductInStock> UpdateProductInStockAsync(ProductInStock ProductInStock)
        {
            _stockContext.Entry(ProductInStock).State = EntityState.Modified;
            await _stockContext.SaveChangesAsync();
            return ProductInStock;
        }
    }
}
