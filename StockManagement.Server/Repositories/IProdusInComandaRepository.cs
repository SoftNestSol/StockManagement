using StockManagement.Server.Entities;
namespace StockManagement.Server.Repositories
{
    public interface IProductInOrderRepository
    {
        Task<ProductInOrder> GetProductInOrderAsync(int ProdusId,int ComandaId);
        Task<List<ProductInOrder>> GetProductInOrdersAsync();

        Task<ProductInOrder> AddProductInOrderAsync(ProductInOrder ProductInOrderInOrder);
        Task DeleteProductInOrderAsync(int ProdusId, int ComandaId);
        Task<ProductInOrder> UpdateProductInOrderAsync(ProductInOrder ProductInOrder);



    }
}
