using HnC.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HnC.Repository.Interfaces
{
    public interface IService
    {
        #region Orders
        Order GetOrder(int userId);
        Task<Order> GetOrderAsync(int userId);
        int AddOrder(int userId);
        Task<int> AddOrderAsync(int userId);
        int RemoveOrder(int userId);
        Task<int> RemoveOrderAsync(int userId);
        #endregion

        #region Order Items
        int AddItemToOrder(int orderId, int itemId, int quantity);
        Task<int> AddItemToOrderAsync(int orderId, int itemId, int quantity);
        List<OrderItem> GetItemsInOrder(int orderId);
        Task<List<OrderItem>> GetItemsInOrderAsync(int orderId);
        OrderItem GetItemInOrder(int orderId, int itemId);
        Task<OrderItem> GetItemInOrderAsync(int orderId, int itemId);
        void UpdateItemQuantityInOrder(int orderId, int itemId, int quantity);
        Task UpdateItemQuantityInOrderAsync(int orderId, int itemId, int quantity);
        int RemoveItemFromOrder(int orderId, int itemId);
        Task<int> RemoveItemFromOrderAsync(int orderId, int itemId);
        void ClearAllItemsFromOrder(int orderId);
        Task ClearAllItemsFromOrderAsync(int orderId);
        #endregion
    }
}