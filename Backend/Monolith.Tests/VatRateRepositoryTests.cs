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
   public class VatRateRepositoryTests
   {
      private Mock<IDataContext> mockContext;
      private VatRate searchedVatRate = new VatRate
      {
         Id = 4
      };

      [SetUp]
      public void Setup()
      {
         var sizeList = new List<VatRate>
         {
            new VatRate
            {
               Id = 1
            },
            new VatRate
            {
               Id = 2
            },
            new VatRate
            {
               Id = 3
            }
         };
         sizeList.Add(searchedVatRate);

         var mockSet = MockSetFactory.SetupMockSet(sizeList);

         mockContext = new Mock<IDataContext>();
         mockContext.Setup(c => c.VatRates).Returns(mockSet.Object);
      }

      [Test]
      public async Task TestGetVatRates()
      {
         var sizeRepository = new VatRateRepository(mockContext.Object);
         var sizeCount = await sizeRepository.GetAll();

         Assert.AreEqual(4, sizeCount.Count());
      }

      [Test]
      public async Task TestGetSpecifiedVatRate()
      {
         var sizeRepository = new VatRateRepository(mockContext.Object);
         var foundSize = await sizeRepository.GetById(searchedVatRate.Id);

         Assert.AreEqual(searchedVatRate, foundSize);
      }
   }
}
