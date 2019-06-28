using System.Threading.Tasks;
using AutoMapper;
using Monolith.DAL.Contracts;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;

namespace MonolithBurgers.Modules.Overview.Service
{
   public class ProductDetailService : IProductDetailService
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
      private readonly IMapper _mapper;

      public ProductDetailService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
         _mapper = mapper;
      }

      public async Task<ProductDetailModel> GetByIdAsync(int id)
      {
         using(var unit = _unitOfWorkFactory.Generate())
         {
            var product = await unit.ProductRepository.GetById(id);
            return _mapper.Map<ProductDetailModel>(product);
         }
      }
   }
}
