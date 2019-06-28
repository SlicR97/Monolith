using MonolithBurgers.Modules.Overview.Models;
using System.Threading.Tasks;

namespace MonolithBurgers.Modules.Overview.Service.Interfaces
{
   public interface IProductDetailService
   {
      Task<ProductDetailModel> GetByIdAsync(int id);
   }
}
