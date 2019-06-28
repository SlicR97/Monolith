using System;

namespace Monolith.DAL.Models
{
   public class Category : ITrackable
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public CategoryId TechnicalCategory { get; set; }

      public DateTime CreatedAt { get; set; }
      public DateTime ModifiedAt { get; set; }
   }

   public enum CategoryId
   {
      Burger = 1,
      Side = 2,
      Drink = 3
   }
}