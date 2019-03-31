using HnC.Repository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HnC.Tests.Repository
{
    [TestClass]
    public class OrderOrderTestsItemTests
    {
        [TestMethod]
        public void AddOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddOrder")
                .Options;

            var userId = 1;
            int orderId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddOrder(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.Orders.Count());
                Assert.AreEqual(orderId, context.Orders.Single().OrderId);
                Assert.AreEqual(userId, context.Orders.Single().UserId);
            }
        }

        [TestMethod]
        public void AddOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AddOrderAsync")
                .Options;

            var userId = 1;
            int orderId;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                orderId = service.AddOrderAsync(userId).GetAwaiter().GetResult();
            }

            //Assert
            using (var context = new Context(options))
            {
                Assert.AreEqual(1, context.Orders.Count());
                Assert.AreEqual(orderId, context.Orders.Single().OrderId);
                Assert.AreEqual(userId, context.Orders.Single().UserId);
            }
        }

        [TestMethod]
        public void GetOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetOrder")
                .Options;

            var userId = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var orderId = service.AddOrder(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var order = service.GetOrder(userId);

                Assert.AreEqual(order.OrderId, context.Orders.First().OrderId);
                Assert.AreEqual(order.UserId, context.Orders.First().UserId);
            }
        }

        [TestMethod]
        public void GetOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GetOrderAsync")
                .Options;

            var userId = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var orderId = service.AddOrder(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var order = service.GetOrderAsync(userId).GetAwaiter().GetResult();

                Assert.AreEqual(order.OrderId, context.Orders.First().OrderId);
                Assert.AreEqual(order.UserId, context.Orders.First().UserId);
            }
        }

        [TestMethod]
        public void RemoveOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveOrder")
                .Options;

            var userId = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var orderId = service.AddOrder(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Check order is added
                Assert.AreEqual(1, context.Orders.Count());

                //Remove order
                var orderId = service.RemoveOrder(userId);

                //Check order has been removed
                Assert.AreEqual(0, context.Orders.Count());
            }
        }

        [TestMethod]
        public void RemoveOrderAsync()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "RemoveOrderAsync")
                .Options;

            var userId = 1;

            //Act
            using (var context = new Context(options))
            {
                var service = new Service(context);
                var orderId = service.AddOrder(userId);
            }

            //Assert
            using (var context = new Context(options))
            {
                var service = new Service(context);

                //Check order is added
                Assert.AreEqual(1, context.Orders.Count());

                //Remove order
                var orderId = service.RemoveOrderAsync(userId).GetAwaiter().GetResult();

                //Check order has been removed
                Assert.AreEqual(0, context.Orders.Count());
            }
        }
    }
}
