using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Server.ContextModels;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;

namespace StockManagement.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly StockContext _stockContext;
        private readonly IMapper _autoMapper;
        private readonly IProductInOrderRepository _productInOrderRepository;

        public OrderController(IOrderRepository orderRepository, StockContext stockContext, IMapper autoMapper, IProductInOrderRepository productInOrderRepository)
        {
            _orderRepository = orderRepository;
            _stockContext = stockContext;
            _autoMapper = autoMapper;
            _productInOrderRepository = productInOrderRepository;
        }
        [HttpGet]
        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders =  await _orderRepository.GetOrdersAsync();

            var OrdersDTO = _autoMapper.Map<List<OrderDTO>>(orders);
            
            return OrdersDTO;

        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);

            var orderDTO = _autoMapper.Map<OrderDTO>(order);

            return orderDTO;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromBody]OrderDTO orderDTO)
        {
            var order = _autoMapper.Map<Order>(orderDTO);

            await _orderRepository.AddOrderAsync(order);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);

            return Ok();
        }
    }
}
