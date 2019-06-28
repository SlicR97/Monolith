using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Monolith.DAL
{
   public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
   {
      public DataContext CreateDbContext(string[] args)
      {
         var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("")
            .Options;

         return new DataContext(options);
      }
   }
}
