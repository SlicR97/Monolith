using System;
using System.IO;
using System.Linq;
using System.Windows;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monolith.DAL;
using Monolith.DAL.Contracts;
using Monolith.DAL.Factories;
using Monolith.DAL.Models;
using MonolithBurger.Infrastructure.Managers;
using MonolithBurger.Infrastructure.Managers.Interface;
using Newtonsoft.Json;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Unity;
using Unity.Injection;

namespace MonolithBurger.Shell
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App
   {
      protected override IModuleCatalog CreateModuleCatalog()
         => new DirectoryModuleCatalog() { ModulePath = @"Modules\." };

      protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
         => moduleCatalog.Initialize();

      protected override void RegisterTypes(IContainerRegistry containerRegistry) 
      {
         containerRegistry
            .GetContainer()
            .RegisterSingleton<IConfigurationProvider>(new InjectionFactory(x => new MapperConfiguration(y => 
            {
               y.ConstructServicesUsing(z => x.Resolve(z));
               AppDomain.CurrentDomain.GetAssemblies()
                  .Where(z => z.GetName().Name.Contains(nameof(MonolithBurger)))
                  .SelectMany(z => z.DefinedTypes.Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract))
                  .ToList()
                  .ForEach(y.AddProfile);
            })))
            .RegisterSingleton<IMapper>(new InjectionFactory(x => x.Resolve<IConfigurationProvider>().CreateMapper()))
            .RegisterSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>(new InjectionConstructor(generateContextOptions(readConnectionString().ConnectionString)))
            .RegisterSingleton<IRegionChangeManager, RegionChangeManager>();
      }

      protected override Window CreateShell()
         => Container.Resolve<MainWindow>();

      private ConnectionStringPoco readConnectionString()
      {
         var filepath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\appsettings.json";
         using (StreamReader file = new StreamReader(filepath))
            return JsonConvert.DeserializeObject<ConnectionStringPoco>(file.ReadToEnd());
      }

      private DbContextOptions<DataContext> generateContextOptions(string connectionString)
         => new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(connectionString)
            .Options;
   }
}
