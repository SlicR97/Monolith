using MonolithBurgers.Modules.Overview.Models;
using System.Collections.Generic;

namespace MonolithBurgers.Modules.Overview.Service.Interfaces
{
   public interface ICartService
   {
      IEnumerable<ProductCartModel> OrderProducts(IEnumerable<ProductModel> products);
   }
}
