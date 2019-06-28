using System;
using System.Collections.Generic;
using System.Linq;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;

namespace MonolithBurgers.Modules.Overview.Service
{
   public class CartService : ICartService
   {
      private List<ProductCartModel> _productsInCart = new List<ProductCartModel>();
      private ProductModel _currentProduct;
      private readonly Func<ProductCartModel, bool> filter;

      public CartService()
      {
         filter = x => x.Product.Id == _currentProduct.Id && x.Size == _currentProduct.Size;
      }

      public IEnumerable<ProductCartModel> OrderProducts(IEnumerable<ProductModel> products)
      {
         _productsInCart = new List<ProductCartModel>();
         foreach(var product in products)
         {
            _currentProduct = product;
            if(productInCart())
               increaseCartProductCount();
            else
               addNewProductToCart();
         }

         _currentProduct = null;
         return _productsInCart;
      }

      private bool productInCart()
         => _productsInCart.Any(filter);

      private void increaseCartProductCount()
         => _productsInCart.FirstOrDefault(filter).Count++;

      private void addNewProductToCart()
         => _productsInCart.Add(new ProductCartModel
         {
            Count = 1,
            Product = _currentProduct,
            Size = _currentProduct.Size
         });
   }
}
