
using System;

namespace StockManagement.Server.Entities
{
    public class ProductInOrder
    {
        public int Order_ID_FK { get; set; }

        public Order Order { get; set; }

        public int Product_ID_FK { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
  
}