using System;


namespace StockManagement.Server.Entities
{
    public class Order
    {
        public int Order_ID { get; set; }
        
        public int Employee_Id { get; set; }
        public Employee Employee { get; set; }

        public int Supplier_ID { get; set; }
        public Supplier Supplier { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } 

        public DateTime Date { get; set; }

        public int NumberOfProducts { get; set; }
    }
}
