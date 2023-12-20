using System;


namespace StockManagement.Server.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Job { get; set; }

        public string Email { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

}

}