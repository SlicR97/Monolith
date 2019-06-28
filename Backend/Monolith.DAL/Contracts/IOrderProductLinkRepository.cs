using Monolith.DAL.Models;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IOrderProductLinkRepository
   {
      Task Add(OrderProduct link);
   }
}
