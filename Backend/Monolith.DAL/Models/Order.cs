using Monolith.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace Monolith.DAL.Models
{
   public class Order : ITrackable
   {
      public int Id { get; set; }

      public bool IsFinished { get; set; }
      public VatRate VatRate { get; set; }
      public double BasePrice { get; set; }
      public double AmountPaid { get; set; }
      public double ChangeGiven { get; set; }
      public double PriceWithVat { get; set; }

      public List<OrderProduct> OrderProducts { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }
}