using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monolith.DAL.Contracts;
using Monolith.DAL.Models;

namespace Monolith.DAL.Repositories
{
   public class ProductRepository : IProductRepository
   {
      private readonly IDataContext _context;

      public ProductRepository(IDataContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<Product>> GetAll()
         => await getNotDeleted().ToListAsync();

      public async Task<Product> GetById(int id)
         => await getNotDeleted().FirstOrDefaultAsync(product => product.Id == id);

      public async Task<IEnumerable<Product>> GetByCategory(int categoryId)
         => await getNotDeleted().Where(product => product.CategoryId == categoryId).ToListAsync();

      private IQueryable<Product> getNotDeleted()
         => _context.Products.Where(x => !x.DelFlag).Include(x => x.Category);

      public async Task Add(Product product)
         => await _context.Products.AddAsync(product);
   }
}
