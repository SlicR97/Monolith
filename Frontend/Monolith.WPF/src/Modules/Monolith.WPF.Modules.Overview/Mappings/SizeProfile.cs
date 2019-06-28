using AutoMapper;
using Monolith.DAL.Models;
using MonolithBurgers.Modules.Overview.Models;

namespace MonolithBurgers.Modules.Overview.Mappings
{
   public class SizeProfile : Profile
   {
      public SizeProfile()
      {
         CreateMap<Size, SizeModel>();
      }
   }
}
