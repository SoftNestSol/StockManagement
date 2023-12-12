using System;


namespace StockManagement.Server.DTOs

{
    public class ProductInOrderDTO
    {
        public int Order_ID_FK { get; set; }

        public int Product_ID_FK { get; set; }

        public int Quantity { get; set; }

    }
  
}
