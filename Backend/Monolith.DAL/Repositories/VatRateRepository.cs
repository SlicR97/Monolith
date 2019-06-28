using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.DAL.Repositories
{
   public class VatRateRepository : IVatRateRepository
   {
      private readonly IDataContext _context;

      public VatRateRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<VatRate>> GetAll()
         => await _context.VatRates.ToListAsync();

      public async Task<VatRate> GetById(int id)
         => await _context.VatRates.FirstOrDefaultAsync(vatRate => vatRate.Id == id);

      public async Task Add(VatRate vatRate)
         => await _context.VatRates.AddAsync(vatRate);
   }
}
