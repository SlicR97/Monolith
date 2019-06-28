using MonolithBurger.Infrastructure.Constants;
using MonolithBurgers.Modules.Overview.Extensions;
using MonolithBurgers.Modules.Overview.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MonolithBurgers.Modules.Overview
{
   public class OverviewModule : IModule
   {
      public void OnInitialized(IContainerProvider containerProvider)
      {
         var regionManager = containerProvider.Resolve<IRegionManager>();

         regionManager.Regions[RegionNames.Menu].Add(containerProvider.Resolve<CategoryView>(), "categories");
         regionManager.Regions[RegionNames.Cart].Add(containerProvider.Resolve<CartView>(), "cart");
      }

      public void RegisterTypes(IContainerRegistry containerRegistry)
      {
         containerRegistry.RegisterSingletonTypes();
         containerRegistry.RegisterNavigationTypes();
      }
   }
}
