using System;


namespace StockManagement.Server.Entities
{
   public class Supplier
   {
      public int Supplier_ID { get; set; }
      public string Name { get; set; }
      public string Address { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
   }
}