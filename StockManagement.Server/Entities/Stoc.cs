using System;

namespace StockManagement.Server.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Location { get; set; }
        public int NumberOfProducts { get; set; }

        public List<ProductInStock> ProductInStock { get; set; }

    }
}