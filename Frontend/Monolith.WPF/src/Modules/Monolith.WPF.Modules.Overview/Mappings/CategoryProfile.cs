using AutoMapper;
using Monolith.DAL.Models;
using MonolithBurgers.Modules.Overview.Models;

namespace MonolithBurgers.Modules.Overview.Mappings
{
   public class CategoryProfile : Profile
   {
      public CategoryProfile()
      {
         CreateMap<Category, CategoryModel>();
      }
   }
}
