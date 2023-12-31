﻿using StockManagement.Server.Entities;
namespace StockManagement.Server.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(int id);
        Task<List<Order>> GetOrdersAsync();

        Task<Order> AddOrderAsync(Order Order);
        Task DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(int id,Order Order);

        

    }
}
