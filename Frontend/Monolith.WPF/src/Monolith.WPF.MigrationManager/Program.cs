using System.Threading.Tasks;

namespace Monolith.MigrationManager
{
   public static class Program
   {
      public static async Task Main(string[] args)
      {
         await new MigrationManager().SeedDb();
      }
   }
}
