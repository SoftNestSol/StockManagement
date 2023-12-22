using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace StockManagement.Server.Repositories
{
    public class ProductInOrderRepository : IProductInOrderRepository
    {
        public readonly StockContext _stockContext;

        public ProductInOrderRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public async Task<ProductInOrder> AddProductInOrderAsync(ProductInOrder ProductInOrder)
        {
            _stockContext.ProductInOrder.Add(ProductInOrder);
            return ProductInOrder;

            
        }

        public async Task DeleteProductInOrderAsync(int ProdusId, int ComandaId)
        {
            
                var ProductInOrder = await _stockContext.ProductInOrder.FindAsync(ProdusId, ComandaId);

                if (ProductInOrder != null)
                {
                    _stockContext.ProductInOrder.Remove(ProductInOrder);

                    await _stockContext.SaveChangesAsync();
                }
        }

        public async Task<ProductInOrder> GetProductInOrderAsync(int ProdusId, int ComandaId)
        {
            var ProductInOrders = await _stockContext.ProductInOrder.FindAsync( ProdusId,  ComandaId);
            return ProductInOrders;
        }

        public async Task<List<ProductInOrder>> GetProductInOrdersAsync()
        {
            var ProductInOrders = await _stockContext.ProductInOrder.ToListAsync();
            return ProductInOrders;
        }

        public async Task<ProductInOrder> UpdateProductInOrderAsync(ProductInOrder ProductInOrder)
        {
            _stockContext.Entry(ProductInOrder).State = EntityState.Modified;
            await _stockContext.SaveChangesAsync();
            return ProductInOrder;
        }
    }
}
