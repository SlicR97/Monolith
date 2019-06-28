using MonolithBurger.Infrastructure.Managers.Interface;
using Prism.Ioc;
using Prism.Regions;

namespace MonolithBurger.Infrastructure.Managers
{
   public class RegionChangeManager : IRegionChangeManager
   {
      private readonly IRegionManager _regionManager;
      private readonly IContainerExtension _containerExtension;

      public RegionChangeManager(IRegionManager regionManager, IContainerExtension containerExtension)
      {
         _regionManager = regionManager;
         _containerExtension = containerExtension;
      }

      public View GetView<View>()
         => _containerExtension.Resolve<View>();

      public void SwitchRegion<View>(View view, string regionName)
      {
         var region = _regionManager.Regions[regionName];
         var views = region.ActiveViews;
         foreach(var activeView in views)
         {
            region.Remove(activeView);
         }

         region.Add(view);
      }

      public void SwitchRegion<View>(string regionName)
      {
         var requestedView = _containerExtension.Resolve<View>();
         SwitchRegion(requestedView, regionName);
      }
   }
}
