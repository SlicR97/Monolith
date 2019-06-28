using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monolith.DAL
{
   public class DataContext : DbContext, IDataContext
   {
      public DataContext(DbContextOptions<DataContext> options) : base(options) { }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         builder.Entity<Size>()
            .HasMany(x => x.OrderProducts)
            .WithOne(x => x.Size)
            .IsRequired(false);
      }

      public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default(CancellationToken))
      {
         onBeforeSaving();
         return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
      }

      public override int SaveChanges()
      {
         onBeforeSaving();
         return base.SaveChanges();
      }

      private void onBeforeSaving()
      {
         var entries = ChangeTracker.Entries();
         foreach(var entry in entries)
         {
            if(entry.Entity is ITrackable trackable)
            {
               var now = DateTime.UtcNow;
               switch (entry.State)
               {
                  case EntityState.Modified:
                     trackable.ModifiedAt = now;
                     break;
                  case EntityState.Added:
                     trackable.CreatedAt = now;
                     trackable.ModifiedAt = now;
                     break;
               }
            }
         }
      }

      public DbSet<Category> Categories { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<Size> Sizes { get; set; }
      public DbSet<VatRate> VatRates { get; set; }

      public DbSet<OrderProduct> OrderProductLink { get; set; }
   }
}
