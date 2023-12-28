using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;

namespace StockManagement.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly StockContext _stockContext;

        public ProductRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public async Task<Product> AddProductAsync(Product Product)
        {
            _stockContext.Products.Add(Product);
            return Product;

            
        }

        public async Task DeleteProductAsync(int id)
        {
            
                var Product = await _stockContext.Products.FirstOrDefaultAsync(o => o.ProductId == id);

                if (Product != null)
                {
                    _stockContext.Products.Remove(Product);

                    await _stockContext.SaveChangesAsync();
                }
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var Products = await _stockContext.Products.FindAsync(id);
            return Products;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var Products = await _stockContext.Products.ToListAsync();
            return Products;
        }

        public async Task<Product> UpdateProductAsync(int id, Product Product)
        {
            _stockContext.Entry(Product).State = EntityState.Modified;
            await _stockContext.SaveChangesAsync();
            return Product;
        }
    }
}
