using System.Threading.Tasks;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.DAL.Repositories
{
   public class OrderRepository : IOrderRepository
   {
      private readonly IDataContext _context;

      public OrderRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task AddNewOrder(Order order)
      {
         await _context.Orders.AddAsync(order);
      }
   }
}
