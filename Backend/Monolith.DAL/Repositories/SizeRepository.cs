using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.DAL.Repositories
{
   public class SizeRepository : ISizeRepository
   {
      private readonly IDataContext _context;

      public SizeRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<Size>> GetAll()
         => await _context.Sizes.ToListAsync();

      public async Task<Size> GetById(int id)
         => await _context.Sizes.FirstOrDefaultAsync(size => size.Id == id);

      public async Task Add(Size size)
         => await _context.Sizes.AddAsync(size);
   }
}
