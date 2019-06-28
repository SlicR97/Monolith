using MonolithBurgers.Modules.Overview.Service;
using MonolithBurgers.Modules.Overview.Service.Interfaces;
using MonolithBurgers.Modules.Overview.Views;
using Prism.Ioc;

namespace MonolithBurgers.Modules.Overview.Extensions
{
   public static class ContainerRegistryExtensions
   {
      public static void RegisterSingletonTypes(this IContainerRegistry container)
      {
         container.RegisterSingleton<IMenuService, MenuService>();
         container.RegisterSingleton<ICategoryService, CategoryService>();
         container.RegisterSingleton<IProductDetailService, ProductDetailService>();
         container.RegisterSingleton<ICartService, CartService>();
         container.RegisterSingleton<ISizeService, SizeService>();
      }

      public static void RegisterNavigationTypes(this IContainerRegistry container)
      {
         container.RegisterForNavigation<CategoryView>();
         container.RegisterForNavigation<MenuView>();
         container.RegisterForNavigation<CartView>();
         container.RegisterForNavigation<ProductDetailView>();
      }
   }
}
