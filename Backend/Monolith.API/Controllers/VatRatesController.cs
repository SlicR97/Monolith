using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.API.Controllers
{
   [Route("/api/[controller]")]
   public class VatRatesController : ControllerBase
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        
      public VatRatesController(IUnitOfWorkFactory unitOfWorkFactory)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         IEnumerable<VatRate> vatRates;
         using(var unit = _unitOfWorkFactory.Generate())
         {
            vatRates = await unit.VatRateRepository.GetAll();
         }

         if (vatRates == null)
            return NotFound();
         return Ok(vatRates);
      }
   }
}