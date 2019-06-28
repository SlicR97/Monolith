using Monolith.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace Monolith.DAL.Models
{
   public class Product : ITrackable
   {
      public int Id { get; set; }

      public string Name { get; set; }
      public string Description { get; set; }
      public string ImageUrl { get; set; }
      public double Price { get; set; }
      public bool DelFlag { get; set; }
      public int CategoryId { get; set; }
      public Category Category { get; set; }

      public virtual ICollection<OrderProduct> OrderProducts { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }
}