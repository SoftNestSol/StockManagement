    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
    using StockManagement.Server.DTOs;
    using StockManagement.Server.Entities;
    using StockManagement.Server.Repositories;
    using System.Drawing;
using System.Text;

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
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDTO)
        {
            // Verificați dacă furnizorul există înainte de orice operațiuni
            var supplier = await _stockContext.Suppliers.FindAsync(orderDTO.SupplierId);
            if (supplier == null)
            {
                return NotFound($"Supplier with ID {orderDTO.SupplierId} not found.");
            }

            // Map the DTO to the domain model for the order
            var order = _autoMapper.Map<Order>(orderDTO);

            // Add the order to the repository first to ensure it has an ID for the products
            await _orderRepository.AddOrderAsync(order);
            // Ensure changes are saved to get an OrderId
            /*await _stockContext.SaveChangesAsync();*/

            // Iterate through the products in the order DTO
            foreach (var productInOrderDTO in orderDTO.ProductInOrder)
            {
                var productInOrderEntity = _autoMapper.Map<ProductInOrder>(productInOrderDTO);

                // Verificați dacă există deja în context sau în baza de date
                var existingEntity = await _stockContext.ProductInOrder
                    .FindAsync(productInOrderDTO.ProductId, productInOrderDTO.OrderId);

                if (existingEntity == null)
                {
                    // Dacă nu există, adăugați noua entitate
                    await _productInOrderRepository.AddProductInOrderAsync(productInOrderEntity);
                }
                else
                {
                    // Dacă există, actualizați entitatea existentă
                    _stockContext.Entry(existingEntity).CurrentValues.SetValues(productInOrderEntity);
                }

            }

            await _stockContext.SaveChangesAsync();



            // Save changes in the context after adding products

            // Prepare the HTML content for the email
            var htmlContentBuilder = new StringBuilder();
            htmlContentBuilder.Append("<h1>Order Confirmation</h1>")
                              .Append("<p>Here are the details of your order:</p>")
                              .Append("<ul>");

            foreach (var productInOrder in orderDTO.ProductInOrder)
            {
                var product = await _stockContext.Products.FindAsync(productInOrder.ProductId);
                htmlContentBuilder.AppendFormat("<li>{0} - Quantity: {1}</li>", product?.Name ?? "Unknown product", productInOrder.Quantity);
            }

            htmlContentBuilder.Append("</ul>");
/*
            // Send the email to the order recipient and supplier
            await _emailService.SendEmailAsync("recipient@example.com", "Order Confirmation", htmlContentBuilder.ToString());
            await _emailService.SendEmailAsync(supplier.Email, "Order Request", htmlContentBuilder.ToString());*/

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
