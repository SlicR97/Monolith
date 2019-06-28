using Monolith.DAL.Contracts;
using Monolith.DAL.Models;
using System.Threading.Tasks;

namespace Monolith.DAL
{
   public class Seed
   {
      private readonly IUnitOfWorkFactory _unitOfWorkFactory;

      public Seed(IUnitOfWorkFactory unitOfWorkFactory)
      {
         _unitOfWorkFactory = unitOfWorkFactory;
      }

      public async Task SeedDb()
      {
         using(var unit = _unitOfWorkFactory.Generate())
         {
            await unit.SizeRepository.Add(new Size
            {
               Name = "Small",
               FillSize = 0.2,
               CostMultiplier = 1,
            });
            await unit.SizeRepository.Add(new Size
            {
               Name = "Medium",
               FillSize = 0.3,
               CostMultiplier = 1.2,
            });
            await unit.SizeRepository.Add(new Size
            {
               Name = "Large",
               FillSize = 0.5,
               CostMultiplier = 1.3
            });

            await unit.CategoryRepository.Add(new Category
            {
               Name = "Burger",
               TechnicalCategory = CategoryId.Burger
            });
            await unit.CategoryRepository.Add(new Category
            {
               Name = "Side Dish",
               TechnicalCategory = CategoryId.Side
            });
            await unit.CategoryRepository.Add(new Category
            {
               Name = "Drink",
               TechnicalCategory = CategoryId.Drink
            });
            
            await unit.VatRateRepository.Add(new VatRate
            {
               Name = "For Here",
               Multiplier = .19
            });
            await unit.VatRateRepository.Add(new VatRate
            {
               Name = "To Go",
               Multiplier = .07
            });

            unit.Complete().Wait();
         }

         using(var unit = _unitOfWorkFactory.Generate())
         {
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Burger),
               DelFlag = false,
               Description = "A burger with cheese",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/601_cheeseburger_product_thumbnail.jpg/77713567-a46c-4c71-9fbb-a05d175cd20f?version=1.0&t=1524732881000",
               Name = "Cheeseburger",
               Price = 3.5
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Burger),
               DelFlag = false,
               Description = "A classic burger",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/11801_hamburger_product_thumbnail.jpg/f1855c1e-dd4a-4e39-9c71-cd4eb490b67d?version=1.0&t=1524725409000",
               Name = "Hamburger",
               Price = 2.2
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Burger),
               DelFlag = false,
               Description = "A burger with bacon",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/10003_big_tasty_bacon_product_thumbnail.jpg/6cb4625b-9320-454e-8fae-f4cfbe2fe6e4?version=2.0&t=1542260881000",
               Name = "Bacon Burger",
               Price = 4
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Drink),
               DelFlag = false,
               Description = "A delicious coke",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/38_coca_cola_product_thumbnail.jpg/ac920cef-db42-4cb1-8c46-c010a5ecc480?version=4.0&t=1542260720000",
               Name = "Coca Cola",
               Price = 1.8
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Drink),
               DelFlag = false,
               Description = "A prickling lemon softdrink",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/40_fanta_product_thumbnail.jpg/dcce0f49-c776-4496-917f-e129c5a4fab9?version=3.0&t=1542260749000",
               Name = "Fanta",
               Price = 1.6
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Drink),
               DelFlag = false,
               Description = "A usual bottled water",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/15222_vio_mineralwasser_medium_product_thumbnail.jpg/d4965316-9569-4145-8418-07e9b696aba8?version=3.0&t=1542260904000",
               Name = "Water",
               Price = 1.4
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Side),
               DelFlag = false,
               Description = "Fries made only of the best potatos",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/28_pommes_frites_gross_product_thumbnail.jpg/1c52ad60-31a0-4f8c-abc5-2dbbc8e9d78c?version=3.0&t=1542260830000",
               Name = "Fries",
               Price = 1.9
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Side),
               DelFlag = false,
               Description = "A salad made of only the most delicious plants",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/12212_big_caesar_chicken_salad_product_thumbnail.jpg/a2ff6302-f270-4520-8676-af03964ffd40?version=2.0&t=1530780383000",
               Name = "Salad",
               Price = 7
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Side),
               DelFlag = false,
               Description = "A creamy cheese soup",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/6401_frucht-quatsch_neu_product_thumbnail.jpg/8a76eacf-74ac-4f8c-a57b-d7e8605875fa?version=1.0&t=1524725907000",
               Name = "Soup",
               Price = 0.9
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Burger),
               DelFlag = false,
               Description = "A burger with delicious chicken",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/80_chicken_burger_product_thumbnail.jpg/2257750e-af03-4cf1-8eb4-80420e2a993f?version=1.0&t=1524725520000",
               Name = "Chickenburger",
               Price = 2
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Burger),
               DelFlag = false,
               Description = "A vegetarian burger",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/10002_veggieburger_ts_product_thumbnail.jpg/b83fedc8-3603-4b89-812f-01e6162da8d9?version=1.0&t=1524725378000",
               Name = "Veggie Burger",
               Price = 2.2
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Side),
               DelFlag = false,
               Description = "Ice in three flavors: Vanilla, Chocolate and Strawberry",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/17302_my_mcflurry_spekulatius-karamell_product_thumbnail.jpg/8c0a4829-3609-4b73-9d58-b1567409265b?version=1.0&t=1542260587000",
               Name = "Ice",
               Price = 1.5
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Side),
               DelFlag = false,
               Description = "A delicious milkshake",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/100_milchshake_erdbeergeschmack_product_thumbnail.jpg/035da6f3-2674-48bb-a201-cbd068b88a73?version=2.0&t=1542260700000",
               Name = "Milkshake",
               Price = 3.5
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Drink),
               DelFlag = false,
               Description = "Wodka made from the rinest waters",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/52_biomilch_product_thumbnail.jpg/90b91d8e-12b5-4fbf-9315-dbfc05af1b21?version=1.0&t=1524726239000",
               Name = "Wodka",
               Price = 4.6
            });
            await unit.ProductRepository.Add(new Product
            {
               Category = await unit.CategoryRepository.GetByTechnicalName(CategoryId.Drink),
               DelFlag = false,
               Description = "SUGAR",
               ImageUrl = "https://www.mcdonalds.de/documents/2729834/2731244/42_sprite_product_thumbnail.jpg/076451e0-51b0-43e6-88da-8173c595f7c8?version=3.0&t=1542260757000",
               Name = "Sprite",
               Price = 2.3
            });

            await unit.Complete();
         }
      }
   }
}