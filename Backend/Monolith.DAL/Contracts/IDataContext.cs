using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Monolith.DAL.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IDataContext : IDisposable
   {
      Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default(CancellationToken));
      int SaveChanges();

      ChangeTracker ChangeTracker { get; }

      DbSet<Category> Categories { get; set; }
      DbSet<Order> Orders { get; set; }
      DbSet<Product> Products { get; set; }
      DbSet<Size> Sizes { get; set; }
      DbSet<VatRate> VatRates { get; set; }

      DbSet<OrderProduct> OrderProductLink { get; set; }
   }
}
