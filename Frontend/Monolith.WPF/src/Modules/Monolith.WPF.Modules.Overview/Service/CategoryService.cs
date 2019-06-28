using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Monolith.DAL.Contracts;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;

namespace MonolithBurgers.Modules.Overview.Service
{
   public class CategoryService : ICategoryService
   {
      private readonly IMapper _mapper;
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;

      public CategoryService(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory)
      {
         _mapper = mapper;
         _unitOfWorkFactory = unitOfWorkFactory;
      }

      public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
      {
         using(var unit = _unitOfWorkFactory.Generate())
         { 
            var categories = await unit.CategoryRepository.GetAll();
            return categories.Select(x => _mapper.Map<CategoryModel>(x));
         }
      }
   }
}
