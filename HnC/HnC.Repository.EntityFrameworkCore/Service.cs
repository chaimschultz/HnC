using HnC.Repository.Interfaces;
using HnC.Repository.Models;
using System;
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
        /// Add items to basket async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int AddItemToBasket(int userId, int itemId, int quantity)
        {
            var basketItem = new Basket { UserId = userId, ItemId = itemId, Quantity = quantity };
            _context.BasketItems.Add(basketItem);
            _context.SaveChanges();
            return basketItem.BasketId;
        }

        /// <summary>
        /// Add new items to basket async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<int> AddItemToBasketAsync(int userId, int itemId, int quantity)
        {
            var basketItem = new Basket { UserId = userId, ItemId = itemId, Quantity = quantity };
            await _context.BasketItems.AddAsync(basketItem);
            await _context.SaveChangesAsync();
            return basketItem.BasketId;
        }

        /// <summary>
        /// Gets items in basket
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Basket> GetItemsInBasket(int userId)
        {
            return _context.BasketItems.Where(x => x.UserId == userId).ToList();
        }

        /// <summary>
        /// Gets items in basket async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Basket>> GetItemsInBasketAsync(int userId)
        {
            return await Task.FromResult(GetItemsInBasket(userId));
        }

        /// <summary>
        /// Updates the quantity of an item in the basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        public void UpdateItemQuantityInBasket(int basketId, int itemId, int quantity)
        {
            var basketItem = _context.BasketItems.SingleOrDefault(x => x.BasketId == basketId && x.ItemId == itemId);
            basketItem.Quantity = quantity;
            _context.BasketItems.Update(basketItem);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the quantity of an item in the basket async
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task UpdateItemQuantityInBasketAsync(int basketId, int itemId, int quantity)
        {
            var basketItem = _context.BasketItems.SingleOrDefault(x => x.BasketId == basketId && x.ItemId == itemId);
            basketItem.Quantity = quantity;
            _context.BasketItems.Update(basketItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an item from the basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        public void RemoveItemFromBasket(int basketId, int itemId)
        {
            var basketItem = _context.BasketItems.SingleOrDefault(x => x.BasketId == basketId && x.ItemId == itemId);
            _context.BasketItems.Remove(basketItem);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes an item from the basket async
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task RemoveItemFromBasketAsync(int basketId, int itemId)
        {
            var basketItem = _context.BasketItems.SingleOrDefault(x => x.BasketId == basketId && x.ItemId == itemId);
            _context.BasketItems.Remove(basketItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes all items from a basket
        /// </summary>
        /// <param name="userId"></param>
        public void ClearAllItemsFromBasket(int userId)
        {
            var itemsToRemove = _context.BasketItems.Where(x => x.UserId == userId);
            _context.BasketItems.RemoveRange(itemsToRemove);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes all items from a basket async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task ClearAllItemsFromBasketAsync(int userId)
        {
            var itemsToRemove = _context.BasketItems.Where(x => x.UserId == userId);
            _context.BasketItems.RemoveRange(itemsToRemove);
            await _context.SaveChangesAsync();
        }
    }
}
