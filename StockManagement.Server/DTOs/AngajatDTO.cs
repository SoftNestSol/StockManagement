using System;


namespace StockManagement.Server.DTOs
{
    public class EmployeeDTO
    {
        public int Employee_ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Job { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

    }
  
}