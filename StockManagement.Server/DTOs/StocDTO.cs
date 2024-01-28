using System;


namespace StockManagement.Server.DTOs
{
    public class StockDTO
    {

        public int StockId { get; set; }

        public string? Location { get; set; }

        public int NumberOfProducts { get; set; }

        public List<ProductInStockDTO>? ProductInStock { get; set; }


    }
}
