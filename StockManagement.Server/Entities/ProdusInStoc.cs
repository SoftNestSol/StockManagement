using System;



namespace StockManagement.Server.Entities

{
    public class ProductInStock
    {
        public int Stock_ID { get; set; }
        public int Product_ID { get; set; }
        public Product Product { get; set; }
        public int Stock_ID { get; set; }
        public Stock Stock { get; set; }
        public int Quantity { get; set; }
    }
}