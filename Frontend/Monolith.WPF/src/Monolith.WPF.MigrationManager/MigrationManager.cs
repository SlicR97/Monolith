using Microsoft.EntityFrameworkCore;
using Monolith.DAL;
using Monolith.DAL.Factories;
using Monolith.DAL.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Monolith.MigrationManager
{
   public class MigrationManager
   {
      private readonly Seed _seed;

      public MigrationManager()
      {
         _seed = new Seed(new UnitOfWorkFactory(generateContextOptions(readConnectionString().ConnectionString)));
      }

      public async Task SeedDb()
      {
         await _seed.SeedDb();
      }

      private ConnectionStringPoco readConnectionString()
      {
         var filepath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\appsettings.json";
         using (StreamReader file = new StreamReader(filepath))
            return JsonConvert.DeserializeObject<ConnectionStringPoco>(file.ReadToEnd());
      }

      private DbContextOptions<DataContext> generateContextOptions(string connectionString)
         => new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(connectionString)
            .Options;
   }
}
