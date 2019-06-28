using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.DAL
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly IDataContext _context;

      public IOrderRepository OrderRepository { get; private set; }
      public IProductRepository ProductRepository { get; private set; }
      public ISizeRepository SizeRepository { get; private set; }
      public IVatRateRepository VatRateRepository { get; private set; }
      public IOrderProductLinkRepository OrderProductLinkRepository { get; private set; }
      public ICategoryRepository CategoryRepository { get; private set; }

      public UnitOfWork(IDataContext context)
      {
         _context = context;

         OrderRepository = new OrderRepository(_context);
         ProductRepository = new ProductRepository(_context);
         SizeRepository = new SizeRepository(_context);
         VatRateRepository = new VatRateRepository(_context);
         OrderProductLinkRepository = new OrderProductLinkRepository(_context);
         CategoryRepository = new CategoryRepository(_context);
      }

      public async Task Complete()
      {
         await _context.SaveChangesAsync();
      }

      public void Dispose()
      {
         _context.Dispose();
      }

      public void Rollback()
      {
         foreach(var entry in _context.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged))
         {
            switch (entry.State)
            {
               case EntityState.Added:
                  entry.State = EntityState.Detached;
                  break;
               case EntityState.Modified:
               case EntityState.Deleted:
                  entry.Reload();
                  break;
            }
         }
      }
   }
}
