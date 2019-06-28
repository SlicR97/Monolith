using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Monolith.Tests.Helpers
{
   static class MockSetFactory
   {
      public static Mock<DbSet<T>> SetupMockSet<T>(List<T> entities) where T : class
      {
         var queryableList = entities.AsQueryable();
         var mockSet = new Mock<DbSet<T>>();

         mockSet.As<IAsyncEnumerable<T>>()
            .Setup(m => m.GetEnumerator())
            .Returns(new TestAsyncEnumerator<T>(queryableList.GetEnumerator()));

         mockSet.As<IQueryable<T>>()
            .Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<T>(queryableList.Provider));

         mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableList.Expression);
         mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
         mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
         return mockSet;
      }
   }
}
