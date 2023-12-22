using StockManagement.Server.Entities;
namespace StockManagement.Server.Repositories
{
    public interface IProductInStockRepository
    {
        Task<ProductInStock> GetProductInStockAsync(int ProdusId,int StocId);
        Task<List<ProductInStock>> GetProductInStocksAsync();
        Task<ProductInStock> AddProductInStockAsync(ProductInStock ProductInStock);
        Task DeleteProductInStockAsync(int ProdusId, int StocId);
        Task<ProductInStock> UpdateProductInStockAsync(ProductInStock ProductInStock);

        

    }
}
