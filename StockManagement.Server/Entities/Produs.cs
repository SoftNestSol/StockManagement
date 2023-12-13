using System;


namespace StockManagement.Server.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<ProductInOrder> ProductInOrder { get; set;}
        public List<ProductInStock> ProductInStock { get; set;}

    }
}