using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace StockManagement.Server.Repositories
{
    public class StockRepository : IStockRepository
    {
        public readonly StockContext _stockContext;

        public StockRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public async Task<Stock> AddStockAsync(Stock Stock)
        {
            _stockContext.Stocks.Add(Stock);
            return Stock;


        }

        public async Task DeleteStockAsync(int id)
        {

            var Stock = await _stockContext.Stocks.FirstOrDefaultAsync(o => o.StockId == id);

            if (Stock != null)
            {
                _stockContext.Stocks.Remove(Stock);

                await _stockContext.SaveChangesAsync();
            }
        }

        public async Task<Stock> GetStockAsync(int id)
        {
            var Stocks = await _stockContext.Stocks.FindAsync(id);
            return Stocks;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            var Stocks = await _stockContext.Stocks.ToListAsync();
            return Stocks;
        }

        public async Task<Stock> UpdateStockAsync(int id, Stock Stock)
        {
            _stockContext.Entry(Stock).State = EntityState.Modified;
            await _stockContext.SaveChangesAsync();
            return Stock;
        }
    }
}
