using Monolith.DAL.Models;
using System.Collections.Generic;

namespace Monolith.API.DTOs
{
   public class OrderForDatabaseDto
   {
      public VatRate VatRate { get; set; }
      public int VatId { get; set; }
      public double BasePrice { get; set; }
      public double AmountPaid { get; set; }

      public List<ProductForOrderDto> Products { get; set; }
   }
}
