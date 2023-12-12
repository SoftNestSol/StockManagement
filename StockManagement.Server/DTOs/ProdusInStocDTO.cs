using System;


namespace StockManagement.Server.DTOs

{
    public class ProductInStockDTO
    {
        public int Stock_ID_FK { get; set; }

        public int Product_ID_FK { get; set; }

        public int Quantity { get; set; }

        public int UnitsSold { get; set; }

    }
  
}
