using MonolithBurger.Infrastructure.Constants;
using MonolithBurger.Infrastructure.Managers.Interface;
using MonolithBurger.Infrastructure.ViewModels;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;
using MonolithBurgers.Modules.Overview.Views;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace MonolithBurgers.Modules.Overview.ViewModels
{
   public class MenuViewModel : ViewModelBase
   {
      private readonly IRegionChangeManager _regionChangeManager;
      private readonly IMenuService _menuService;
      private IEnumerable<ProductModel> _products;

      public MenuViewModel(IMenuService menuService, IRegionChangeManager regionChangeManager)
      {
         _menuService = menuService;
         _regionChangeManager = regionChangeManager;

         InitializeCommand = new DelegateCommand(OnInitializeCommandExecute, OnInitializeCommandCanExecute);
         BackCommand = new DelegateCommand(OnBackCommandExecute);
         SelectProductCommand = new DelegateCommand<ProductModel>(OnSelectProductExecute, OnSelectProductCanExecute);
      }

      public ICommand SelectProductCommand { get; set; }
      public ICommand BackCommand { get; set; }
      public CategoryModel Category { get; set; }
      public IEnumerable<ProductModel> Products
      {
         get => _products;
         set => SetProperty(ref _products, value);
      }

      private bool OnInitializeCommandCanExecute()
         => !IsInitialized;

      private async void OnInitializeCommandExecute()
      {
         IsInitialized = true;
         Products = await _menuService.GetProductsByCategoryAsync(Category.Id);
      }

      private void OnBackCommandExecute()
      {
         _regionChangeManager.SwitchRegion<CategoryView>(RegionNames.Menu);
      }

      private bool OnSelectProductCanExecute(ProductModel product)
         => product != null;

      private void OnSelectProductExecute(ProductModel product)
      {
         var productDetailView = _regionChangeManager.GetView<ProductDetailView>();
         ((ProductDetailViewModel)productDetailView.DataContext).Product = product;
         ((ProductDetailViewModel)productDetailView.DataContext).Category = Category;
         _regionChangeManager.SwitchRegion(productDetailView, RegionNames.Menu);
      }
   }
}
