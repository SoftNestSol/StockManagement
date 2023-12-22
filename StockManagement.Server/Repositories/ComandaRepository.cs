using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace StockManagement.Server.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly StockContext _stockContext;

        public OrderRepository(StockContext stockContext)
        {
            _stockContext = stockContext;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _stockContext.Orders.Add(order);
            return order;


        }

        public async Task DeleteOrderAsync(int id)
        {

            var order = await _stockContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (order != null)
            {
                _stockContext.Orders.Remove(order);

                await _stockContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var Orders = await _stockContext.Orders.FindAsync(id);
            return Orders;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var Orders = await _stockContext.Orders.ToListAsync();
            return Orders;
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            _stockContext.Entry(order).State = EntityState.Modified;
            await _stockContext.SaveChangesAsync();
            return order;
        }
    }
}
