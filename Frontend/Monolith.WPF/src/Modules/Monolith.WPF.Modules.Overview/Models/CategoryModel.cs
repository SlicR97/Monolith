using Monolith.DAL.Models;

namespace MonolithBurgers.Modules.Overview.Models
{
   public class CategoryModel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public CategoryId TechnicalCategory { get; set; }
   }
}