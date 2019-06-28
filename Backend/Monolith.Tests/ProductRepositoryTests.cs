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
   public class ProductRepositoryTests
   {
      private Mock<IDataContext> mockContext;
      private Product searchedProduct = new Product
      {
         Id = 4
      };

      [SetUp]
      public void Setup()
      {
         var productList = new List<Product>
         {
            new Product
            {
               Id = 1
            },
            new Product
            {
               Id = 2
            },
            new Product
            {
               Id = 3
            }
         };
         productList.Add(searchedProduct);

         var mockSet = MockSetFactory.SetupMockSet(productList);

         mockContext = new Mock<IDataContext>();
         mockContext.Setup(c => c.Products).Returns(mockSet.Object);
      }

      [Test]
      public async Task TestGetProductById()
      {
         var productRepository = new ProductRepository(mockContext.Object);
         var foundProduct = await productRepository.GetById(4);

         Assert.AreEqual(searchedProduct, foundProduct);
      }

      [Test]
      public async Task TestGetAllProducts()
      {
         var productRepository = new ProductRepository(mockContext.Object);
         var foundProducts = await productRepository.GetAll();

         Assert.AreEqual(4, foundProducts.Count());
      }
   }
}