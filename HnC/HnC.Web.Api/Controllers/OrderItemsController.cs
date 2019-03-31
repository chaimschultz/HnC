using HnC.Repository.Interfaces;
using HnC.Repository.Models;
using HnC.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HnC.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        IService _repoService;

        public OrderItemsController(IService repoService)
        {
            _repoService = repoService;
        }

        [HttpGet("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }

        [HttpGet("orders/{orderId}/items")]
        [ProducesResponseType(typeof(List<OrderItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetItems(int orderId)
        {
            try
            {
                if (orderId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                var items = await
                    _repoService.GetItemsInOrderAsync(orderId);

                if (items == null)
                    return new StatusCodeResult(StatusCodes.Status404NotFound);

                var response = items.Select(x => new OrderItemResponse
                    {
                        ItemId = x.ItemId,
                        OrderId = x.OrderId,
                        Quantity = x.Quantity
                    }
                );


                return Ok(response);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("orders/{orderId}/items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddItem(int orderId, [FromBody]AddItemRequest item)
        {
            try
            {
                if (orderId < 1
                    || item.ItemId < 1
                    || item.Quantity < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                var result = await
                    _repoService.AddItemToOrderAsync(orderId, item.ItemId, item.Quantity);

                if (result > 0)
                    return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        
        [HttpPut("orders/{orderId}/items/{itemId}/quantity/{quantity}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateItemQuantity(int orderId, int itemId, int quantity)
        {
            try
            {
                if (orderId < 1
                    || itemId < 1
                    || quantity < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                await _repoService.UpdateItemQuantityInOrderAsync(orderId, itemId, quantity);

                return new StatusCodeResult(StatusCodes.Status202Accepted);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
    }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("orders/{orderId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveItem(int orderId, int itemId)
        {
            try
            {
                if (orderId < 1
                    || itemId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                //Check if it already exists
                var item = await
                    _repoService.GetItemInOrderAsync(orderId, itemId);

                if (item == null)
                    return new StatusCodeResult(StatusCodes.Status404NotFound);

                var result = await
                    _repoService.RemoveItemFromOrderAsync(orderId, itemId);

                if (result > 0)
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("orders/{orderId}/items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ClearOrderItems(int orderId)
        {
            try
            {
                if (orderId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                await _repoService.ClearAllItemsFromOrderAsync(orderId);

                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
