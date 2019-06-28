using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.API.Controllers
{
   [Route("/api/[controller]")]
   public class SizesController : ControllerBase
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        
      public SizesController(IUnitOfWorkFactory unitOfWorkFactory)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         IEnumerable<Size> sizes;
         using (var unit = _unitOfWorkFactory.Generate())
         {
            sizes = await unit.SizeRepository.GetAll();
         }

         if (sizes == null)
            return NotFound();
         return Ok(sizes);
      }
   }
}