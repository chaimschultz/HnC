using HnC.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HnC.Repository.Interfaces
{
    public interface IService
    {
        int AddItemToBasket(int userId, int itemId, int quantity);
        Task<int> AddItemToBasketAsync(int userId, int itemId, int quantity);
        List<Basket> GetItemsInBasket(int userId);
        Task<List<Basket>> GetItemsInBasketAsync(int userId);
        void UpdateItemQuantityInBasket(int basketId, int itemId, int quantity);
        Task UpdateItemQuantityInBasketAsync(int basketId, int itemId, int quantity);
        void RemoveItemFromBasket(int basketId, int itemId);
        Task RemoveItemFromBasketAsync(int basketId, int itemId);
        void ClearAllItemsFromBasket(int userId);
        Task ClearAllItemsFromBasketAsync(int userId);
    }
}