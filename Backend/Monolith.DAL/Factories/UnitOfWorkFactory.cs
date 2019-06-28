using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;

namespace Monolith.DAL.Factories
{
   public class UnitOfWorkFactory : IUnitOfWorkFactory
   {
      private readonly DbContextOptions<DataContext> _options;

      public UnitOfWorkFactory(DbContextOptions<DataContext> options)
      {
         _options = options;
      }

      public IUnitOfWork Generate()
      {
         return new UnitOfWork(new DataContext(_options));
      }
   }
}
