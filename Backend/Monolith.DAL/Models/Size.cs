using Monolith.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace Monolith.DAL.Models
{
   public class Size : ITrackable
   {
      public int Id { get; set; }

      public string Name { get; set; }
      public double FillSize { get; set; }
      public double CostMultiplier { get; set; }

      public virtual ICollection<OrderProduct> OrderProducts { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }
}