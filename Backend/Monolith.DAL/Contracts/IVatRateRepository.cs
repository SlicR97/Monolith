using Monolith.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolith.DAL.Contracts
{
   public interface IVatRateRepository
   {
      Task<IEnumerable<VatRate>> GetAll();
      Task<VatRate> GetById(int id);
      Task Add(VatRate vatRate);
   }
}
