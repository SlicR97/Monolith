using AutoMapper;
using Monolith.API.DTOs;
using Monolith.DAL.Models;

namespace Monolith.API.Helpers
{
   public class AutoMapperProfiles : Profile
   {
      public AutoMapperProfiles()
      {
         CreateMap<Product, ProductForListDto>();
         CreateMap<OrderForDatabaseDto, Order>()
            .ForMember(dest => dest.PriceWithVat, opt => opt.MapFrom(source => source.BasePrice + (source.BasePrice * source.VatRate.Multiplier)))
            .ForMember(dest => dest.ChangeGiven, opt => opt.MapFrom(source => source.AmountPaid - (source.BasePrice + (source.BasePrice * source.VatRate.Multiplier))));
      }
   }
}
