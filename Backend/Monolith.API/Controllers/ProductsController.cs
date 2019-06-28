using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monolith.API.DTOs;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.API.Controllers
{
   [Route("api/[controller]")]
   public class ProductsController : ControllerBase
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
      private readonly IMapper _mapper;
        
      public ProductsController(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
         _mapper = mapper;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         IEnumerable<Product> products;
         using(var unit = _unitOfWorkFactory.Generate())
         {
            products = await unit.ProductRepository.GetAll();
         }

         var res = new List<ProductForListDto>();
         foreach(var product in products)
         {
            res.Add(_mapper.Map<ProductForListDto>(product));
         }
         return Ok(res);
      }
   }
}