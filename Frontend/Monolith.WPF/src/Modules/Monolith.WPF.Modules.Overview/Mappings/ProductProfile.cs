using AutoMapper;
using Monolith.DAL.Models;
using MonolithBurgers.Modules.Overview.Models;

namespace MonolithBurgers.Modules.Overview.Mappings
{
   public class ProductProfile : Profile
   {
      public ProductProfile()
      {
         CreateMap<Product, ProductModel>();
         CreateMap<Product, ProductDetailModel>();
      }
   }
}
