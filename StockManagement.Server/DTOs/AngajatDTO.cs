using System;


namespace StockManagement.Server.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }
        public string Job { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }

    }
  
}