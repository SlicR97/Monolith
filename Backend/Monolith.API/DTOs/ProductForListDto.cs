using Monolith.DAL.Models;

namespace Monolith.API.DTOs
{
   public class ProductForListDto
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public double Price { get; set; }
      public string ImageUrl { get; set; }
      public Category Category { get; set; }
   }
}
