using HnC.Repository.Interfaces;
using HnC.Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HnC.Repository.EntityFrameworkCore
{
    public class Service : IService
    {
        private readonly Context _context;

        public Service(Context dbContext)
        {
            _context = dbContext;
        }
        
        /// <summary>
        /// Add a new Order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int AddOrder(int userId)
        {
            var orderItem = new Order { UserId = userId };
            var result = _context.Orders.Add(orderItem);
            _context.SaveChanges();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Add a new Order async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> AddOrderAsync(int userId)
        {
            var orderItem = new Order { UserId = userId };
            var result = _context.Orders.Add(orderItem);
            await _context.SaveChangesAsync();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Gets an existing order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Order GetOrder(int userId)
        {
            return _context.Orders.SingleOrDefault(x => x.UserId == userId);
        }

        /// <summary>
        /// Gets an existing order async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<Order> GetOrderAsync(int userId)
        {
            return Task.FromResult(_context.Orders.SingleOrDefault(x => x.UserId == userId));
        }

        /// <summary>
        /// Removes an existing order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int RemoveOrder(int userId)
        {
            var order = _context.Orders.SingleOrDefault(x => x.UserId == userId);
            var result = _context.Orders.Remove(order);
            _context.SaveChanges();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Removes an existing order async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<int> RemoveOrderAsync(int userId)
        {
            var order = _context.Orders.SingleOrDefault(x => x.UserId == userId);
            var result = _context.Orders.Remove(order);
            _context.SaveChanges();
            return Task.FromResult<int>(result.Entity.OrderId);
        }

        /// <summary>
        /// Add items to Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int AddItemToOrder(int orderId, int itemId, int quantity)
        {
            var orderItem = new OrderItem { OrderId=orderId, ItemId = itemId, Quantity = quantity };
            var result = _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Add new items to Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<int> AddItemToOrderAsync(int orderId, int itemId, int quantity)
        {
            var orderItem = new OrderItem { OrderId = orderId, ItemId = itemId, Quantity = quantity };
            var result = await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Gets items in Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderItem> GetItemsInOrder(int orderId)
        {
            return _context.OrderItems.Where(x => x.OrderId == orderId).ToList();
        }

        /// <summary>
        /// Gets items in Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<List<OrderItem>> GetItemsInOrderAsync(int orderId)
        {
            return await Task.FromResult(GetItemsInOrder(orderId));
        }

        /// <summary>
        /// Gets an item in Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public OrderItem GetItemInOrder(int orderId, int itemId)
        {
            return _context.OrderItems.SingleOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
        }

        /// <summary>
        /// Gets an item in Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<OrderItem> GetItemInOrderAsync(int orderId, int itemId)
        {
            return await Task.FromResult(GetItemInOrder(orderId, itemId));
        }

        /// <summary>
        /// Updates the quantity of an item in the Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        public void UpdateItemQuantityInOrder(int orderId, int itemId, int quantity)
        {
            var OrderItem = _context.OrderItems.SingleOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
            OrderItem.Quantity = quantity;
            _context.OrderItems.Update(OrderItem);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the quantity of an item in the Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task UpdateItemQuantityInOrderAsync(int orderId, int itemId, int quantity)
        {
            var OrderItem = _context.OrderItems.SingleOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
            OrderItem.Quantity = quantity;
            _context.OrderItems.Update(OrderItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an item from the Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        public int RemoveItemFromOrder(int orderId, int itemId)
        {
            var OrderItem = _context.OrderItems.SingleOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
            var result = _context.OrderItems.Remove(OrderItem);
            _context.SaveChanges();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Removes an item from the Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<int> RemoveItemFromOrderAsync(int orderId, int itemId)
        {
            var OrderItem = _context.OrderItems.SingleOrDefault(x => x.OrderId == orderId && x.ItemId == itemId);
            var result = _context.OrderItems.Remove(OrderItem);
            await _context.SaveChangesAsync();
            return result.Entity.OrderId;
        }

        /// <summary>
        /// Removes all items from the Order
        /// </summary>
        /// <param name="orderId"></param>
        public void ClearAllItemsFromOrder(int orderId)
        {
            var itemsToRemove = _context.OrderItems.Where(x => x.OrderId == orderId);
            _context.OrderItems.RemoveRange(itemsToRemove);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes all items from the Order async
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task ClearAllItemsFromOrderAsync(int orderId)
        {
            var itemsToRemove = _context.OrderItems.Where(x => x.OrderId == orderId);
            _context.OrderItems.RemoveRange(itemsToRemove);
            await _context.SaveChangesAsync();
        }

    }
}
