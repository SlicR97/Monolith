using Monolith.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface ISizeRepository
   {
      Task<IEnumerable<Size>> GetAll();
      Task<Size> GetById(int id);
      Task Add(Size size);
   }
}
