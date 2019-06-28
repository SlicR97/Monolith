using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MonolithBurger.Infrastructure.ViewModels;
using MonolithBurgers.Modules.Overview.Events;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;
using Prism.Commands;
using Prism.Events;

namespace MonolithBurgers.Modules.Overview.ViewModels
{
   public class CartViewModel : ViewModelBase
   {
      private readonly ICartService _cartService;
      private IEnumerable<ProductCartModel> _productsInCart;

      public CartViewModel(IEventAggregator eventAggregator, ICartService cartService)
      {
         _cartService = cartService;
         eventAggregator.GetEvent<ProductSelectedEvent>().Subscribe(OnProductSelected);
         RemoveProductFromCartCommand = new DelegateCommand<ProductCartModel>(OnRemoveProductFromCartCommandExecute, OnRemoveProductFromCartCommandCanExecute);
      }

      public ICommand RemoveProductFromCartCommand { get; set; }
      public IList<ProductModel> Products { get; set; } = new List<ProductModel>();
      public IEnumerable<ProductCartModel> CartProducts 
      { 
         get => _productsInCart;
         set => SetProperty(ref _productsInCart, value);
      }

      private void OnProductSelected(ProductModel product)
      {
         Products.Add(product);
         orderProductList();
      }

      private void orderProductList()
      {
         CartProducts = _cartService.OrderProducts(Products);
      }

      private void OnRemoveProductFromCartCommandExecute(ProductCartModel product)
      {
         Products.Remove(product.Product);
         orderProductList();
      }

      private bool OnRemoveProductFromCartCommandCanExecute(ProductCartModel product)
         => product != null;
   }
}
