using Monolith.DAL.Models;
using MonolithBurger.Infrastructure.Constants;
using MonolithBurger.Infrastructure.Managers.Interface;
using MonolithBurger.Infrastructure.ViewModels;
using MonolithBurgers.Modules.Overview.Events;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;
using MonolithBurgers.Modules.Overview.Views;
using Prism.Commands;
using Prism.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MonolithBurgers.Modules.Overview.ViewModels
{
   public class ProductDetailViewModel : ViewModelBase
   {
      private readonly IRegionChangeManager _regionChangeManager;
      private readonly IEventAggregator _eventAggregator;
      private readonly IProductDetailService _productDetailService;
      private readonly ISizeService _sizeService;
      private ProductModel _product;
      private CategoryModel _category;
      private ProductDetailModel _detailedProduct;
      private SizeModel _selectedSize;
      private IEnumerable<SizeModel> _sizes;

      public ProductDetailViewModel(IRegionChangeManager regionChangeManager, IEventAggregator eventAggregator, IProductDetailService productDetailService, ISizeService sizeService)
      {
         _regionChangeManager = regionChangeManager;
         _eventAggregator = eventAggregator;
         _productDetailService = productDetailService;
         _sizeService = sizeService;

         AddProductToCartCommand = new DelegateCommand(OnAddProductToCartCommandExecute);
         BackToOverViewCommand = new DelegateCommand(OnBackToOverviewCommandExecute);
         InitializeCommand = new DelegateCommand(OnInitializeCommandExecute, OnInitializeCommandCanExecute);

         Sizes = new List<SizeModel>();
      }

      public Visibility IsDrink 
         => Product.Category.TechnicalCategory == CategoryId.Drink 
            ? Visibility.Visible 
            : Visibility.Hidden;
      public ICommand AddProductToCartCommand { get; set; }
      public ICommand BackToOverViewCommand { get; set; }

      public SizeModel SelectedSize
      {
         get => _selectedSize;
         set
         {
            DetailedProduct.Size = value;
            RaisePropertyChanged(nameof(DetailedProduct.Size));
            RaisePropertyChanged(nameof(DetailedProduct.FullPrice));
         }
      }

      public IEnumerable<SizeModel> Sizes
      { 
         get => _sizes;
         set => SetProperty(ref _sizes, value);
      }

      public ProductModel Product 
      { 
         get => _product;
         set => SetProperty(ref _product, value);
      }

      public CategoryModel Category
      {
         get => _category;
         set => SetProperty(ref _category, value);
      }

      public ProductDetailModel DetailedProduct 
      { 
         get => _detailedProduct;
         set => SetProperty(ref _detailedProduct, value);
      }

      private void OnAddProductToCartCommandExecute()
      {
         _eventAggregator.GetEvent<ProductSelectedEvent>().Publish(Product);
         OnBackToOverviewCommandExecute();
      }

      private void OnBackToOverviewCommandExecute()
      {
         var menuView = _regionChangeManager.GetView<MenuView>();
         ((MenuViewModel)menuView.DataContext).Category = Category;
         _regionChangeManager.SwitchRegion(menuView, RegionNames.Menu);
      }

      private async void OnInitializeCommandExecute()
      {
         IsInitialized = true;
         DetailedProduct = await _productDetailService.GetByIdAsync(Product.Id);
         Sizes = new List<SizeModel>(await _sizeService.GetSizes());
      }

      private bool OnInitializeCommandCanExecute()
         => !IsInitialized;
   }
}
