namespace MonolithBurgers.Modules.Overview.Models
{
   public class ProductDetailModel : ProductModel
   {
      public string Description { get; set; }
      public double Price { get; set; }

      public double FullPrice
         => Size == null
            ? Price
            : Price * Size.CostMultiplier;
   }
}
