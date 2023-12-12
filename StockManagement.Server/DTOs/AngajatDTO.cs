using System;


namespace StockManagement.Server.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Job { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

    }
  
}