using System;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IUnitOfWork : IDisposable
   {
      IOrderRepository OrderRepository { get; }
      IProductRepository ProductRepository { get; }
      ISizeRepository SizeRepository { get; }
      IVatRateRepository VatRateRepository { get; }
      IOrderProductLinkRepository OrderProductLinkRepository { get; }
      ICategoryRepository CategoryRepository { get; }

      Task Complete();
      void Rollback();
   }
}
