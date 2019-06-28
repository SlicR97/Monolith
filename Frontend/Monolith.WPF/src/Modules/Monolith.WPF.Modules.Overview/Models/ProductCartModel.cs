using Monolith.DAL.Models;

namespace MonolithBurgers.Modules.Overview.Models
{
   public class ProductCartModel
   {
      public int Count { get; set; }
      public ProductModel Product { get; set; }
      public bool IsDrink => Product.Category.TechnicalCategory == CategoryId.Drink;
      public SizeModel Size { get; set; }
   }
}
