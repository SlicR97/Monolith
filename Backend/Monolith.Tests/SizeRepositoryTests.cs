using Monolith.DAL.Contracts;
using Monolith.DAL.Models;
using Monolith.DAL.Repositories;
using Monolith.Tests.Helpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Tests
{
   [TestFixture]
   public class SizeRepositoryTests
   {
      private Mock<IDataContext> mockContext;
      private Size searchedSize = new Size
      {
         Id = 4
      };

      [SetUp]
      public void Setup()
      {
         var sizeList = new List<Size>
         {
            new Size
            {
               Id = 1
            },
            new Size
            {
               Id = 2
            },
            new Size
            {
               Id = 3
            }
         };
         sizeList.Add(searchedSize);

         var mockSet = MockSetFactory.SetupMockSet(sizeList);

         mockContext = new Mock<IDataContext>();
         mockContext.Setup(c => c.Sizes).Returns(mockSet.Object);
      }

      [Test]
      public async Task TestGetSizes()
      {
         var sizeRepository = new SizeRepository(mockContext.Object);
         var sizeCount = await sizeRepository.GetAll();

         Assert.AreEqual(4, sizeCount.Count());
      }

      [Test]
      public async Task TestGetSpecifiedSize()
      {
         var sizeRepository = new SizeRepository(mockContext.Object);
         var foundSize = await sizeRepository.GetById(searchedSize.Id);

         Assert.AreEqual(searchedSize, foundSize);
      }
   }
}
