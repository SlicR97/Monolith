using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Monolith.DAL.Contracts;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;

namespace MonolithBurgers.Modules.Overview.Service
{
   public class MenuService : IMenuService
   {
      private readonly IMapper _mapper;
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;

      public MenuService(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory)
      {
         _mapper = mapper;
         _unitOfWorkFactory = unitOfWorkFactory;
      }

      public async Task<IEnumerable<ProductModel>> GetProductsByCategoryAsync(int categoryId)
      {
         using(var unit = _unitOfWorkFactory.Generate())
         {
            var products = await unit.ProductRepository.GetByCategory(categoryId);
            return products.Select(x => _mapper.Map<ProductModel>(x));
         }
      }
   }
}
