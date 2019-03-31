using HnC.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HnC.Tests
{
    [TestClass]
    public class OrderItemTests
    {
        //private int GetNewOrder(DbContextOptions<Context> options, int userId)
        //{
        //    int orderId;

        //    using (var context = new Context(options))
        //    {
        //        var service = new Service(context);
        //        orderId = service.AddOrder(userId);
        //    }

        //    return orderId;
        //}



        [TestMethod]
        public void AddItemToOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddItemToOrder")
                .Options;

            var orderId = 1;
            var itemId = 1;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                service.AddItemToOrder(orderId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.OrderItems.Count());
                Assert.AreEqual(orderId, context.OrderItems.Single().OrderId);
                Assert.AreEqual(itemId, context.OrderItems.Single().ItemId);
                Assert.AreEqual(quantity, context.OrderItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void AddItemToOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddItemToOrderAsync")
                .Options;

            var orderId = 1;
            var itemId = 1;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                service.AddItemToOrderAsync(orderId, itemId, quantity).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.OrderItems.Count());
                Assert.AreEqual(orderId, context.OrderItems.Single().OrderId);
                Assert.AreEqual(itemId, context.OrderItems.Single().ItemId);
                Assert.AreEqual(quantity, context.OrderItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void GetItemsInOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetItemsInOrder")
                .Options;

            var orderId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the Order
                while (count <= 4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToOrder(orderId, itemId, quantity);
                }
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Get Items
                var items = service.GetItemsInOrder(orderId);

                Assert.AreEqual(items.Count, context.OrderItems.Count());
                Assert.AreEqual(items.First().OrderId, context.OrderItems.First().OrderId);
                Assert.AreEqual(items.First().ItemId, context.OrderItems.First().ItemId);
                Assert.AreEqual(items.First().Quantity, context.OrderItems.First().Quantity);
            }
        }

        [TestMethod]
        public void GetItemsInOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetItemsInOrderAsync")
                .Options;

            var orderId = 1;
            int itemId;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Add 4 items to the Order
                while (count <= 4)
                {
                    count++;
                    itemId = count;
                    service.AddItemToOrder(orderId, itemId, quantity);
                }
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Get Items
                var items = service.GetItemsInOrderAsync(orderId).GetAwaiter().GetResult();

                Assert.AreEqual(items.Count, context.OrderItems.Count());
                Assert.AreEqual(items.First().OrderId, context.OrderItems.First().OrderId);
                Assert.AreEqual(items.First().ItemId, context.OrderItems.First().ItemId);
                Assert.AreEqual(items.First().Quantity, context.OrderItems.First().Quantity);
            }
        }

        [TestMethod]
        public void UpdateItemQuantityInOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "UpdateItemQuantityInOrder")
                .Options;

            var orderId = 1;
            var itemId = 4;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddItemToOrder(orderId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                quantity = quantity + 3;
                service.UpdateItemQuantityInOrder(orderId, itemId, quantity);

                Assert.AreEqual(1, context.OrderItems.Count());
                Assert.AreEqual(orderId, context.OrderItems.Single().OrderId);
                Assert.AreEqual(itemId, context.OrderItems.Single().ItemId);
                Assert.AreEqual(quantity, context.OrderItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void UpdateItemQuantityInOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "UpdateItemQuantityInOrderAsync")
                .Options;

            var orderId = 1;
            var itemId = 4;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddItemToOrder(orderId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                quantity = quantity + 3;
                service.UpdateItemQuantityInOrderAsync(orderId, itemId, quantity).GetAwaiter().GetResult();

                Assert.AreEqual(1, context.OrderItems.Count());
                Assert.AreEqual(orderId, context.OrderItems.Single().OrderId);
                Assert.AreEqual(itemId, context.OrderItems.Single().ItemId);
                Assert.AreEqual(quantity, context.OrderItems.Single().Quantity);
            }
        }

        [TestMethod]
        public void RemoveItemFromOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveItemFromOrder")
                .Options;

            var orderId = 1;
            var itemId = 4;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddItemToOrder(orderId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.OrderItems.Count());

                var service = new Service(context);
                service.RemoveItemFromOrder(orderId, itemId);

                Assert.IsTrue(context.OrderItems.Count(x => x.OrderId == orderId) == 0);
                Assert.AreEqual(0, context.OrderItems.Count());
            }
        }

        [TestMethod]
        public void RemoveItemFromOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveItemFromOrder")
                .Options;

            var orderId = 1;
            var itemId = 4;
            var quantity = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddItemToOrder(orderId, itemId, quantity);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.OrderItems.Count());

                var service = new Service(context);
                service.RemoveItemFromOrderAsync(orderId, itemId).GetAwaiter().GetResult();

                Assert.IsTrue(context.OrderItems.Count(x => x.OrderId == orderId) == 0);
                Assert.AreEqual(0, context.OrderItems.Count());
            }
        }

        [TestMethod]
        public void ClearAllItemsFromOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ClearAllItemsFromOrder")
                .Options;

            var orderId = 1;
            var itemId = 1;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                //Add 4 items to the Order
                while (count <= 4)
                {
                    count++;
                    itemId++;
                    orderId = service.AddItemToOrder(orderId, itemId, quantity);
                }
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                //Clear items
                service.ClearAllItemsFromOrder(orderId);

                Assert.IsTrue(context.OrderItems.Count(x => x.OrderId == orderId) == 0);
                Assert.AreEqual(0, context.OrderItems.Count());
            }
        }

        [TestMethod]
        public void ClearAllItemsFromOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ClearAllItemsFromOrder")
                .Options;

            var orderId = 1;
            var itemId = 1;
            var quantity = 1;
            var count = 0;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                //Add 4 items to the Order
                while (count <= 4)
                {
                    count++;
                    itemId++;
                    orderId = service.AddItemToOrder(orderId, itemId, quantity);
                }
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                //Clear items
                service.ClearAllItemsFromOrderAsync(orderId).GetAwaiter().GetResult();

                Assert.IsTrue(context.OrderItems.Count(x => x.OrderId == orderId) == 0);
                Assert.AreEqual(0, context.OrderItems.Count());
            }
        }
    }
}
