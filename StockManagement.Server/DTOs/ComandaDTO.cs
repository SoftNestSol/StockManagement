using System;

namespace StockManagement.Server.DTOs
{
    public class OrderDTO
    {
        public int Order_ID { get; set; }

        public int Employee_ID_FK { get; set; }

        public int Supplier_ID_FK { get; set; }

        public string Status { get; set; }

        public DateTime Date {  get; set; }

        public int NumberOfProducts { get; set; }


    }
}
