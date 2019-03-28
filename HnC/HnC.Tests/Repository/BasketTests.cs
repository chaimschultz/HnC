using HnC.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace HnC.Tests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void AddItemToBasket()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddItemToBasket")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using(var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasket(userId, itemId, quantity);
            }

            //Assert
            using(var context = new Context(options))
            {
                Assert.AreEqual(1, context.BasketItems.Count());
                Assert.AreEqual(basketId, context.BasketItems.Single().BasketId);
                Assert.AreEqual(userId, context.BasketItems.Single().UserId);
                Assert.AreEqual(itemId, context.BasketItems.Single().ItemId);
                Assert.AreEqual(quantity, context.BasketItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void AddItemToBasketAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddItemToBasketAsync")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasketAsync(userId, itemId, quantity).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.BasketItems.Count());
                Assert.AreEqual(basketId, context.BasketItems.Single().BasketId);
                Assert.AreEqual(userId, context.BasketItems.Single().UserId);
                Assert.AreEqual(itemId, context.BasketItems.Single().ItemId);
                Assert.AreEqual(quantity, context.BasketItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void GetItemsInBasket()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetItemsInBasket")
                .Options;

            var userId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the basket
                while (count <= 4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToBasket(userId, itemId, quantity);
                }

                //Assert items are added
                Assert.AreEqual(count, context.BasketItems.Count());
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Get Items
                var items = service.GetItemsInBasket(userId);

                Assert.AreEqual(items.Count, context.BasketItems.Count());
                Assert.AreEqual(items.First().BasketId, context.BasketItems.First().BasketId);
                Assert.AreEqual(items.First().UserId, context.BasketItems.First().UserId);
                Assert.AreEqual(items.First().ItemId, context.BasketItems.First().ItemId);
                Assert.AreEqual(items.First().Quantity, context.BasketItems.First().Quantity);
            }
        }

        [TestMethod]
        public void GetItemsInBasketAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetItemsInBasketAsync")
                .Options;

            var userId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the basket
                while (count <= 4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToBasket(userId, itemId, quantity);
                }

                //Assert items are added
                Assert.AreEqual(count, context.BasketItems.Count());
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Get Items
                var items = service.GetItemsInBasketAsync(userId).GetAwaiter().GetResult();

                Assert.AreEqual(items.Count, context.BasketItems.Count());
                Assert.AreEqual(items.First().BasketId, context.BasketItems.First().BasketId);
                Assert.AreEqual(items.First().UserId, context.BasketItems.First().UserId);
                Assert.AreEqual(items.First().ItemId, context.BasketItems.First().ItemId);
                Assert.AreEqual(items.First().Quantity, context.BasketItems.First().Quantity);
            }
        }

        [TestMethod]
        public void UpdateItemQuantityInBasket()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "UpdateItemQuantityInBasket")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasket(userId, itemId, quantity);
                quantity = quantity + 3;
                service.UpdateItemQuantityInBasket(basketId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.BasketItems.Count());
                Assert.AreEqual(basketId, context.BasketItems.Single().BasketId);
                Assert.AreEqual(userId, context.BasketItems.Single().UserId);
                Assert.AreEqual(itemId, context.BasketItems.Single().ItemId);
                Assert.AreEqual(quantity, context.BasketItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void UpdateItemQuantityInBasketAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "UpdateItemQuantityInBasketAsync")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasket(userId, itemId, quantity);
                quantity = quantity + 3;
                service.UpdateItemQuantityInBasketAsync(basketId, itemId, quantity).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.BasketItems.Count());
                Assert.AreEqual(basketId, context.BasketItems.Single().BasketId);
                Assert.AreEqual(userId, context.BasketItems.Single().UserId);
                Assert.AreEqual(itemId, context.BasketItems.Single().ItemId);
                Assert.AreEqual(quantity, context.BasketItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void RemoveItemFromBasket()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveItemFromBasket")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasket(userId, itemId, quantity);
                service.RemoveItemFromBasket(basketId, itemId);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.IsTrue(context.BasketItems.Count(x => x.BasketId == basketId) == 0);
                Assert.AreEqual(0, context.BasketItems.Count());
            }
        }

        [TestMethod]
        public void RemoveItemFromBasketAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveItemFromBasketAsync")
                .Options;

            var userId = 1;
            var itemId = 4;
            var quantity = 1;
            int basketId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                basketId = service.AddItemToBasket(userId, itemId, quantity);
                service.RemoveItemFromBasketAsync(basketId, itemId).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.IsTrue(context.BasketItems.Count(x => x.BasketId == basketId) == 0);
                Assert.AreEqual(0, context.BasketItems.Count());
            }
        }

        [TestMethod]
        public void ClearAllItemsFromBasket()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ClearAllItemsFromBasket")
                .Options;

            var userId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the basket
                while (count<=4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToBasket(userId, itemId, quantity);
                }

                //Assert items are added
                Assert.AreEqual(count, context.BasketItems.Count());

                //Clear items
                service.ClearAllItemsFromBasket(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.IsTrue(context.BasketItems.Count(x => x.UserId == userId) == 0);
                Assert.AreEqual(0, context.BasketItems.Count());
            }
        }

        [TestMethod]
        public void ClearAllItemsFromBasketAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ClearAllItemsFromBasketAsync")
                .Options;

            var userId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the basket
                while (count <= 4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToBasket(userId, itemId, quantity);
                }

                //Assert items are added
                Assert.AreEqual(count, context.BasketItems.Count());

                //Clear items
                service.ClearAllItemsFromBasketAsync(userId).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.IsTrue(context.BasketItems.Count(x => x.UserId == userId) == 0);
                Assert.AreEqual(0, context.BasketItems.Count());
            }
        }
    }
}
