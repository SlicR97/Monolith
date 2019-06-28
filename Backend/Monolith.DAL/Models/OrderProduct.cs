using Monolith.DAL.Contracts;
using System;

namespace Monolith.DAL.Models
{
   public class OrderProduct : ITrackable
   {
      public int Id { get; set; }

      public int OrderId { get; set; }
      public Order Order { get; set; }

      public int ProductId { get; set; }
      public Product Product { get; set; }
      
      public int? SizeId { get; set; }
      public Size Size { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }
}