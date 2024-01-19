
using System;


namespace StockManagement.Server.Entities

{
    public class ProductInStock
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int UnitsSold { get; set; }

    }
  
}
