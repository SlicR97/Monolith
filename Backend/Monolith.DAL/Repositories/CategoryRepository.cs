using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.DAL.Repositories
{
   public class CategoryRepository : ICategoryRepository
   {
      private readonly IDataContext _context;

      public CategoryRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<Category>> GetAll()
         => await _context.Categories.ToListAsync();

      public async Task Add(Category category)
         => await _context.Categories.AddAsync(category);

      public async Task<Category> GetByTechnicalName(CategoryId categoryId)
         => await _context.Categories.FirstOrDefaultAsync(x => x.TechnicalCategory == categoryId);
   }
}
