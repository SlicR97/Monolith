using Monolith.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IProductRepository
   {
      Task<IEnumerable<Product>> GetAll();
      Task<Product> GetById(int id);
      Task<IEnumerable<Product>> GetByCategory(int categoryId);
      Task Add(Product product);
   }
}
