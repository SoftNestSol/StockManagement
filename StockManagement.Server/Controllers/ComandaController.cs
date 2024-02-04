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

            private readonly IEmailService _emailService;

            public OrderController(IOrderRepository orderRepository, StockContext stockContext, IMapper autoMapper, IProductInOrderRepository productInOrderRepository, IEmailService emailService)
            {
                _orderRepository = orderRepository;
                _stockContext = stockContext;
                _autoMapper = autoMapper;
                _productInOrderRepository = productInOrderRepository;
                _emailService = emailService;

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

                var productsInOrder = orderDTO.ProductInOrder;

                foreach (var productInOrder in productsInOrder)
                {
                    var productInOrderEntity = _autoMapper.Map<ProductInOrder>(productInOrder);
                    await _productInOrderRepository.AddProductInOrderAsync(productInOrderEntity);
                }

                await _stockContext.SaveChangesAsync();

                var SupplierId = order.SupplierId;

                var supplier = await _stockContext.Suppliers.FindAsync(SupplierId);

                var htmlContentBuilder = new System.Text.StringBuilder();
                htmlContentBuilder.Append("<h1>Order Confirmation</h1>");
                htmlContentBuilder.Append("<p>Here are the details of your order:</p>");
                htmlContentBuilder.Append("<ul>");

                foreach (var productInOrder in orderDTO.ProductInOrder)
                {
                    var product = await _stockContext.Products.FindAsync(productInOrder.ProductId);
                 htmlContentBuilder.AppendFormat("<li>{0} - Quantity: {1}</li>", product.Name, productInOrder.Quantity);
                }

                htmlContentBuilder.Append("</ul>");

                await _emailService.SendEmailAsync("recipient@example.com", "Order Confirmation", htmlContentBuilder.ToString());

                var email = supplier.Email;

                await _emailService.SendEmailAsync(email, "Order Request", htmlContentBuilder.ToString());
                
                return Ok();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOrder(int id)
            {
                await _orderRepository.DeleteOrderAsync(id);

                return Ok();
            }

            [HttpPost("receive-order")]
            public async Task<IActionResult> ReceiveOrder([FromBody]OrderDTO orderDTO)
            {
                var order = _autoMapper.Map<Order>(orderDTO);

            //  await _orderRepository.ReceiveOrderAsync(order);

                return Ok();
            }
        }
    }
