using Monolith.DAL.Models;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IOrderRepository
   {
      Task AddNewOrder(Order order);
   }
}
