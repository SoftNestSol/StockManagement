using System;


namespace StockManagement.Server.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } 

        public DateTime Date { get; set; }

        public int NumberOfProducts { get; set; }

        public List<ProductInOrder> ProductInOrder { get; set; }
    }
}
