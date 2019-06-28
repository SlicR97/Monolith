using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monolith.API.DTOs;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.API.Controllers
{
   [Route("/api/[controller]")]
   public class OrdersController : ControllerBase
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;
      private readonly IMapper _mapper;

      public OrdersController(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
         _mapper = mapper;
      }

      [HttpPost]
      public async Task<ActionResult> Add([FromBody] OrderForDatabaseDto orderForDatabase)
      {
         using(var unit = _unitOfWorkFactory.Generate())
         {
            orderForDatabase.VatRate = await unit.VatRateRepository.GetById(orderForDatabase.VatId);
            var order = _mapper.Map<Order>(orderForDatabase);
            await unit.OrderRepository.AddNewOrder(order);

            orderForDatabase.Products.ForEach(async product =>
            {
               await unit.OrderProductLinkRepository.Add(new OrderProduct
               {
                  ProductId = product.ProductId,
                  SizeId = product.SizeId,
                  Order = order
               });
            });

            await unit.Complete();
         }

         return StatusCode(201);
      }
   }
}