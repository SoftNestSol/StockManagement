using System;


namespace StockManagement.Server.Entities
{
   public class Supplier
   {
      public int SupplierId { get; set; }
      public string Name { get; set; }
      public string Address { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
   }
}