using Monolith.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface ICategoryRepository
   {
      Task<IEnumerable<Category>> GetAll();
      Task<Category> GetByTechnicalName(CategoryId categoryId);
      Task Add(Category category);
   }
}
