using MonolithBurgers.Modules.Overview.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonolithBurgers.Modules.Overview.Service.Interfaces
{
   public interface ICategoryService
   {
      Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
   }
}