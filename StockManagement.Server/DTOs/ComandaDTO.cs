using System;

namespace StockManagement.Server.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int EmployeeId { get; set; }

        public int SupplierId{ get; set; }

        public string Status { get; set; }

        public DateTime Date {  get; set; }

        public int NumberOfProducts { get; set; }


    }
}
