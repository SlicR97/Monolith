using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Monolith.Tests.Helpers
{
   class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
   {
      public TestAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
      public TestAsyncEnumerable(Expression expression) : base(expression) { }

      public IAsyncEnumerator<T> GetEnumerator()
      {
         return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
      }

      IQueryProvider IQueryable.Provider
      {
         get => new TestAsyncQueryProvider<T>(this);
      }
   }
}
