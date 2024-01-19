    using System;


namespace StockManagement.Server.DTOs

{
    public class ProductInOrderDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UnitsSold { get; set; }
    }
  
}
