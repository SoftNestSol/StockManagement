using StockManagement.Server.Entities;
using 
namespace StockManagement.Server.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetProductsAsync();

        Task<Product> AddProductAsync(Product Product);
        Task DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(int id,Product Product);

        

    }
}
