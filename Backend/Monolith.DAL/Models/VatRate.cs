using System;
using Monolith.DAL.Contracts;

namespace Monolith.DAL.Models
{
   public class VatRate : ITrackable
   {
      public int Id { get; set; }

      public string Name { get; set; }
      public double Multiplier { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }
}