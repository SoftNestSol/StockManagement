using System;


namespace StockManagement.Server.DTOs

{
    public class ProductInStockDTO
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UnitsSold { get; set; }

    }
  
}
