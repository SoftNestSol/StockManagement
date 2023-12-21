using StockManagement.Server.Entities;
namespace StockManagement.Server.Repositories
{
    public interface IStockRepository
    {
        Task<Stock> GetStockAsync(int id);
        Task<List<Stock>> GetStocksAsync();

        Task<Stock> AddStockAsync(Stock Stock);
        Task DeleteStockAsync(int id);
        Task<Stock> UpdateStockAsync(int id,Stock Stock);

        

    }
}
