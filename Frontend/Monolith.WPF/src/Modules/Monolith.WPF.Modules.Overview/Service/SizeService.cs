using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Monolith.DAL.Contracts;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;

namespace MonolithBurgers.Modules.Overview.Service
{
   public class SizeService : ISizeService
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
      private readonly IMapper _mapper;

      public SizeService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
         _mapper = mapper;
      }

      public async Task<IEnumerable<SizeModel>> GetSizes()
      {
         using(var unit = _unitOfWorkFactory.Generate())
         {
            var sizes = await unit.SizeRepository.GetAll();
            return sizes.Select(x => _mapper.Map<SizeModel>(x));
         }
      }
   }
}
