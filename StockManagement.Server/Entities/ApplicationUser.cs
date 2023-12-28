using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace StockManagement.Server.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Employee Employee { get; set; }

        public int? EmployeeId { get; set; }


    }
}