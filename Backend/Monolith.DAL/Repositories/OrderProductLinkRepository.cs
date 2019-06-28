using Monolith.DAL.Contracts;
using Monolith.DAL.Models;
using System.Threading.Tasks;

namespace Monolith.DAL.Repositories
{
   class OrderProductLinkRepository : IOrderProductLinkRepository
   {
      private readonly IDataContext _context;

      public OrderProductLinkRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task Add(OrderProduct link)
      {
         await _context.OrderProductLink.AddAsync(link);
      }
   }
}
